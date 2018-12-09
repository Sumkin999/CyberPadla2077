﻿using System;
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
        public StateIdle(StateController stateController)
        {
            StateController = stateController;
            CommandsInState.Add(new CommandMove());
            CommandsInState.Add(new ComandAim());

            CommandsInState[0].StateController = StateController;
            CommandsInState[1].StateController = stateController;

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
