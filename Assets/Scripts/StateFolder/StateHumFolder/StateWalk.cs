using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.ComandFolder.Commands;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateWalk:StateBase
    {
        public StateWalk(StateController stateController)
        {
            StateController = stateController;
            CommandsInState.Add(new CommandMove());
            CommandsInState.Add(new ComandAim());

            CommandsInState[0].StateController = StateController;
            CommandsInState[1].StateController = stateController;

            StateFlags.CanMove = true;
            StateFlags.IsMoving = true;
            StateFlags.IsAiming = false;
        }

        public override void StateEnterAction()
        {
            StateController.AnimatorModule.ToggleWalk(true);
        }
        public override void StateExitAction(StateBase stateTo)
        {
            if (!stateTo.StateFlags.CanMove)
            {
                StateController.AnimatorModule.ToggleWalk(false);
            }
        }
    }
}
