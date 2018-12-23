using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.ComandFolder.Commands;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateIdle:StateBase
    {
        public StateIdle(StateController stateController):base(stateController)
        {
            //StateController = stateController;

            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h=>h is CommandMove));
            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is ComandAim));
            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is ComandSelectWeapon));
            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is ComandRotate));
            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is ComandFall));
            /*CommandsInState.Add(new CommandMove(true));
            CommandsInState.Add(new ComandAim());
            CommandsInState.Add(new ComandSelectWeapon());
            CommandsInState.Add(new ComandRotate(true));
            CommandsInState.Add(new ComandFall());

            CommandsInState[0].StateController = StateController;
            CommandsInState[1].StateController = StateController;
            CommandsInState[2].StateController = StateController;
            CommandsInState[3].StateController = StateController;
            CommandsInState[4].StateController = StateController;*/

            FillCommandsNotInState();

            StateFlags.CanMove = true;
            StateFlags.IsMoving = false;
            StateFlags.IsAiming = false;
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
