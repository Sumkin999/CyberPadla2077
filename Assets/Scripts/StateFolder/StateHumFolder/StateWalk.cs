using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateWalk:StateBase
    {
        public StateWalk(StateController stateController)
        {
            StateController = stateController;
            CommandsInState.Add(new CommandMove());
           
            CommandsInState[0].StateController = StateController;
        }

        public override void StateEnterAction()
        {
            StateController.AnimatorModule.ToggleWalk(true);
        }
    }
}
