using Braveior.BuddyRewards.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.Services.Interfaces
{
    public interface IDataService
    {

        List<MemberDTO> SearchMember(string key);

        TableDataDTO<MemberDTO> GetMembers(TableStateDTO tableState);

        TableDataDTO<RatingDTO> GetRatings(TableStateDTO tableState);

        Task AddRating(RatingDTO rating);

        List<AverageRatingDTO> GetAverageRatings(string ratedFor);


    }
}
