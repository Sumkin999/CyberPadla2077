﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateFalled:StateBase
    {
        public StateFalled(StateController stateController)
        {
            StateController = stateController;
            /*CommandsInState.Add(new CommandMove(true));
            CommandsInState.Add(new ComandAim());
            CommandsInState.Add(new ComandSelectWeapon());
            CommandsInState.Add(new ComandRotate(true));

            CommandsInState[0].StateController = StateController;
            CommandsInState[1].StateController = StateController;
            CommandsInState[2].StateController = StateController;
            CommandsInState[3].StateController = StateController;*/

            StateFlags.CanMove = false;
            StateFlags.IsMoving = false;
            StateFlags.IsAiming = false;
        }

        public override void StateEnterAction()
        {
            
        }
    }
}