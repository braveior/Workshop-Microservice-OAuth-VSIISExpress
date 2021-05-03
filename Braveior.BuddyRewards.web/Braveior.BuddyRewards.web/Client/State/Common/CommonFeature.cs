using Fluxor;

namespace Braveior.BuddyRewards.web.Client.State.Common
{
	public class CommonFeature : Feature<CommonState>
	{
        public override string GetName() => "Common";
        protected override CommonState GetInitialState() =>
            new CommonState(
                loggedInUser: null
               );
    }
}
