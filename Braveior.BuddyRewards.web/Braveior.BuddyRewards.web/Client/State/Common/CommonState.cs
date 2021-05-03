using Braveior.BuddyRewards.web.Client.DTO;

namespace Braveior.BuddyRewards.web.Client.State.Common
{
	public class CommonState
	{

		public MemberDTO LoggedInUser { get; }


		public CommonState(MemberDTO loggedInUser)
		{
			LoggedInUser = loggedInUser;
		}
	}
}
