﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandAttack:Command
    {

        protected override bool GetInputData(ComandDataBase comandData)
        {
            ComandDataAttack comandDataAttack=comandData as ComandDataAttack;
            if (comandDataAttack!=null)
            {
                if (comandDataAttack.IsPrimaryPressed)
                {

                    StateController.WeaponModule.SetPressedFlags(comandDataAttack.IsPrimaryPressed,comandDataAttack.IsSecondaryPressed);
                    //StartCommando();
                }

                return true;
            }
            return false;
        }


        
        protected override void ExecuteAction()
        {
            
            


        }

        protected override bool ContinueCommandoCheck()
        {
            if (StateController.WeaponModule.CheckIfAttackAvailable())
            {
                return true;
            }
            return false;
        }

        protected override void BreakCommandoAction()
        {
            StateController.AddTrigger(TriggersTemp.TriggerUnaim);
            /*if (StateController.CurrentState.StateFlags.IsAiming)
            {

                StateController.Triggers.Add(TriggersTemp.TriggerUnaim);
            }*/
        }


    }
}
