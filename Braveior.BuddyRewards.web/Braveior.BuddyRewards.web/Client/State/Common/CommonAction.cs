using Braveior.BuddyRewards.web.Client.DTO;

namespace Braveior.BuddyRewards.web.Client.State.Common
{
    public class CommonAction
    {
        public MemberDTO LoggedInUser;
        public CommonAction(MemberDTO user)
        {
            LoggedInUser = user;
        }
    }
}
