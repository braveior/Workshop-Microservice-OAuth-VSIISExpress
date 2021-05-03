using Braveior.BuddyRewards.web.Client.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.web.Client.Services
{
    public interface IDataService
    {
        Task<List<MemberDTO>> SearchMembers(string key);

        Task<TableDataDTO<MemberDTO>> GetMembers(TableStateDTO tableState);

        Task<TableDataDTO<RatingDTO>> GetRatings(TableStateDTO tableState);
        Task<bool> SubmitRating(RatingDTO rating);

        Task<List<GraphDataDTO>> GetAverageRatings(string ratingFor);
            
    }
}
