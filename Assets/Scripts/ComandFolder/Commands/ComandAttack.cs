using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandAttack:Command
    {
        public override void IniciateCommand()
        {
            StartCommando();
        }
        protected override bool GetInputData(ComandDataBase comandData)
        {
            ComandDataAttack comandDataAttack=comandData as ComandDataAttack;
            if (comandDataAttack!=null)
            {
                if (comandDataAttack.IsPrimaryPressed)
                {

                    StateController.WeaponModule.SetPressedFlags(comandDataAttack.IsPrimaryPressed,comandDataAttack.IsSecondaryPressed);
                    
                }

                return true;
            }
            return false;
        }


        
        protected override void ExecuteAction()
        {

            if (!StateController.WeaponModule.CheckIfAttackAvailable() && !StateController.WeaponModule.CheckIfAttackInProgress())
            {
                StateController.AddTrigger(TriggersTemp.TriggerUnaim);
            }


        }

        protected override bool ContinueCommandoCheck()
        {
            
            return true;
        }

        


    }
}
