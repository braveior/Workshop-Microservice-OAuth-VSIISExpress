using Fluxor;

namespace Braveior.BuddyRewards.web.Client.State.Common
{
	public class CommonReducers
	{
		[ReducerMethod]
		public static CommonState ReduceAction(CommonState state, CommonAction action) =>
	new CommonState(
		loggedInUser: null
		);

		[ReducerMethod]
		public static CommonState ReduceResultAction(CommonState state, CommonResultAction action) =>
			new CommonState(
				loggedInUser: action.LoggedInUser);
	}
}
