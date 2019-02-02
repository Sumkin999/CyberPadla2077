using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandAim:Command
    {
        public override void IniciateCommand()
        {
            StartCommando();
        }
        protected override bool GetInputData(ComandDataBase comandData)
        {
            ComandDataAim comandDataAim=comandData as ComandDataAim;
            if (comandDataAim!=null)
            {
                
                StateController.WeaponModule.SetPressedFlags(comandDataAim.IsPrimaryPressed,comandDataAim.IsSecondaryPressed);


                return true;
                
            }

            return false;
        }

        
        protected override void ExecuteAction()
        {

            if (StateController.WeaponModule.CheckIfAttackAvailable()  ||  StateController.WeaponModule.CheckIfAttackInProgress())
                StateController.AddTrigger(TriggersTemp.TriggerAim);
            
            
        }
        protected override bool ContinueCommandoCheck()
        {
            return true;
        }

    }
}
