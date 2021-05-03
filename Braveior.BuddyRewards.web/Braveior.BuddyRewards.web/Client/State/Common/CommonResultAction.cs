using Braveior.BuddyRewards.web.Client.DTO;

namespace Braveior.BuddyRewards.web.Client.State.Common
{
    public class CommonResultAction
    {
        public MemberDTO LoggedInUser { get; }


        public CommonResultAction(MemberDTO user)
        {
            LoggedInUser = user;
        }
    }
}
