using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateIdle:StateBase
    {
        public StateIdle(StateController stateController)
        {
            StateController = stateController;
            CommandsInState.Add(new CommandMove());
            
            CommandsInState[0].StateController = StateController;
        }
        public override void StateEnterAction()
        {
            StateController.AnimatorModule.ToggleWalk(false);
        }
    }
}
