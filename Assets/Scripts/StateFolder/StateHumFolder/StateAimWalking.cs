using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.ComandFolder.Commands;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateAimWalking:StateBase
    {
        public StateAimWalking(StateController stateController)
        {
            StateController = stateController;
            CommandsInState.Add(new CommandMove(true));
            CommandsInState.Add(new ComandAim());

            CommandsInState[0].StateController = StateController;
            CommandsInState[1].StateController = stateController;

            StateFlags.CanMove = true;
            StateFlags.IsMoving = true;
            StateFlags.IsAiming = true;
        }
        public override void StateEnterAction()
        {
            StateController.AnimatorModule.ToggleAim(true, StateController.WeaponModule.CurrentWeapon);
            StateController.AnimatorModule.ToggleWalk(true);
        }

        public override void StateExitAction(StateBase stateTo)
        {
            if (!stateTo.StateFlags.IsAiming)
            {
                StateController.AnimatorModule.ToggleAim(false, StateController.WeaponModule.CurrentWeapon);
            }
        }
    }
}
