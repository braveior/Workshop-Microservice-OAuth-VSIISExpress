using Braveior.BuddyRewards.DTO;
using Braveior.BuddyRewards.Services.Interfaces;
using Braveior.BuddyRewards.Services.Models;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using AutoMapper;
using System.Threading;
using Serilog;

namespace Braveior.BuddyRewards.Services
{
    /// <summary>
    /// Dataservice connects to the MongoDB instance to interact with data.
    /// </summary>
    public class DataService : IDataService
    {
        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public DataService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
            
        /// <summary>
        /// Search for Member documents starting with the key string
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<MemberDTO> SearchMember(string key)
        {
            if (key.Length > 1)
            {

                var members = DB.Queryable<Member>().Where(m => m.Name.ToLower().StartsWith(key)).ToList();
                return _mapper.Map<List<MemberDTO>>(members);

            }
            else
                return new List<MemberDTO>();

        }
        /// <summary>
        /// Get paginated data for the Member documents
        /// </summary>
        /// <param name="tableState"></param>
        /// <returns></returns>
        public  TableDataDTO<MemberDTO> GetMembers(TableStateDTO tableState)
        {
            var members = DB.Queryable<Member>();
            if (tableState.SearchKey.Length > 0)
            {
                members= members.Where(m => m.Name.ToLower().StartsWith(tableState.SearchKey));
            }
            var totalCount = members.Count();
            if (tableState.SortDirection == "Ascending")
            {
                members = members.OrderBy(c => c.Name)
                                .Skip(tableState.Page * tableState.PageSize)
                                .Take(tableState.PageSize);
            }
            else
            {
                members = members.OrderByDescending(c => c.Name)
                            .Skip(tableState.Page * tableState.PageSize)
                            .Take(tableState.PageSize);
            }
            return new TableDataDTO<MemberDTO> { PagedMemberData = _mapper.Map<List<MemberDTO>>(members.ToList()) , TotalCount= totalCount} ;
                            
        }
        /// <summary>
        /// Get paginated data for the Rating documents
        /// </summary>
        /// <param name="tableState"></param>
        /// <returns></returns>
        public TableDataDTO<RatingDTO> GetRatings(TableStateDTO tableState)
        {
            var ratings = DB.Queryable<Rating>().Where(a => a.RatedForRef.ID == tableState.FilterID);
            var totalCount = ratings.Count();
            if (tableState.SortDirection == "Ascending")
            {
                ratings = ratings.OrderBy(c => c.RatingDate)
                                .Skip(tableState.Page * tableState.PageSize)
                                .Take(tableState.PageSize);
            }
            else
            {
                ratings = ratings.OrderByDescending(c => c.RatingDate)
                            .Skip(tableState.Page * tableState.PageSize)
                            .Take(tableState.PageSize);
            }

            return new TableDataDTO<RatingDTO> { PagedMemberData = _mapper.Map<List<RatingDTO>>(ratings.ToList()), TotalCount = totalCount };

        }
        /// <summary>
        /// Add a new Rating document
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task AddRating(RatingDTO rating)
        {
            var oneMonthOldDate = DateTime.Now.AddMonths(-1);
            var currentRating = await DB.Find<Rating>().ManyAsync(r => (r.RatingDate > oneMonthOldDate && r.RatedByRef.ID == rating.RatedByRef && r.RatedForRef.ID == rating.RatedForRef));
            if (currentRating != null && currentRating.Count>0)
            {
                throw new  Exception("Rating already Found for the same Month and Year");                
            }

            var ratedForEntity = await DB.Find<Member>().OneAsync(rating.RatedForRef);
            var ratedByEntity = await DB.Find<Member>().OneAsync(rating.RatedByRef);

            var ratingEntity = new Rating { Star = rating.Star, Comment = rating.Comment, RatedByRef = ratedByEntity.ToReference(), RatedForRef = ratedForEntity.ToReference(), RatingDate = DateTime.Now, RatedBy = ratedByEntity.Name, RatedFor = ratedForEntity.Name };
            await ratingEntity.SaveAsync();
            _logger.Information($"Rating added for {ratingEntity}");

        }
        /// <summary>
        /// Get the Monthly average ratings for a member
        /// </summary>
        /// <param name="ratedFor"></param>
        /// <returns></returns>
        public List<AverageRatingDTO> GetAverageRatings(string ratedFor)
        {
            var oneYearOldDate = DateTime.Now.AddYears(-1);
            var averageRatings = DB.Queryable<Rating>().Where(a=>a.RatedForRef.ID == ratedFor && a.RatingDate > oneYearOldDate)
                                .GroupBy(a => a.RatingDate.Month)
                                .Select(g => new AverageRatingDTO { Month = g.Key, Star = g.Average(a=>a.Star) })
                                .ToList();

            return averageRatings;
        }


    }
}
