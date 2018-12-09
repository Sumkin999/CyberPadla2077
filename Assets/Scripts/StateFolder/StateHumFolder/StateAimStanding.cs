using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateAimStanding:StateBase
    {
        public StateAimStanding(StateController stateController)
        {
            StateController = stateController;
            CommandsInState.Add(new CommandMove());
           

            CommandsInState[0].StateController = StateController;
        }
        public override void StateEnterAction()
        {
            StateController.AnimatorModule.ToggleWalk(false);
        }
        public override void StateExitAction(StateBase stateTo)
        {

        }
    }
}
