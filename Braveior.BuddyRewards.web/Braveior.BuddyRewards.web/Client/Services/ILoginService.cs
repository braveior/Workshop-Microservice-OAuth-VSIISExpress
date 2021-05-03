using Braveior.BuddyRewards.web.Client.DTO;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.web.Client.Services
{
    public interface ILoginService
    {
        public Task<MemberDTO> LoginAsync(LoginDTO userDTO);
        public Task<MemberDTO> GetUserByAccessTokenAsync(string accessToken);
    }
}
