using Braveior.BuddyRewards.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.Services.Interfaces
{
    public interface ILoginService
    {
        MemberDTO Login(LoginDTO user);
        Task<MemberDTO> GetUserFromAccessToken(string accessToken);
    }
}
