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
    public class StateWalk:StateBase
    {
        public StateWalk(StateController stateController)
        {
            StateController = stateController;

            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is CommandMove));
            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is ComandAim));
            CommandsInState.Add(StateController.StateComandManager.AllCommands.Find(h => h is ComandSelectWeapon));
            /*CommandsInState.Add(new CommandMove(true));
            CommandsInState.Add(new ComandAim());
            CommandsInState.Add(new ComandSelectWeapon());

            CommandsInState[0].StateController = StateController;
            CommandsInState[1].StateController = StateController;
            CommandsInState[2].StateController = StateController;*/

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
            if (!stateTo.StateFlags.IsMoving)
            {
                StateController.TransformModule.MoveTargetVector3 = StateController.TransformModule.MainTransform.position;
                //StateController.TransformModule.NavMeshAgent.destination = StateController.TransformModule.MainTransform.position;
                //StateController.TransformModule.NavMeshAgent.isStopped = true;
                
                StateController.AnimatorModule.ToggleWalk(false);
            }
        }
    }
}
