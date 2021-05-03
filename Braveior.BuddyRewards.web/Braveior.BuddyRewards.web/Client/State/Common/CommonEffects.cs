using Fluxor;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.web.Client.State.Common
{
	public class CommonEffects
	{


		public CommonEffects()
		{

		}

		[EffectMethod]
		public async Task HandleAction(CommonAction action, IDispatcher dispatcher)
		{
			dispatcher.Dispatch(new CommonResultAction(action.LoggedInUser));
		}
	}
}
