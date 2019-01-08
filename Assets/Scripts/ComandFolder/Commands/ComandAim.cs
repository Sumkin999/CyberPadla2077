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
        
        protected override bool GetInputData(ComandDataBase comandData)
        {
            ComandDataAim comandDataAim=comandData as ComandDataAim;
            if (comandDataAim!=null)
            {
                
                StateController.WeaponModule.SetPressedFlags(comandDataAim.IsPrimaryPressed,comandDataAim.IsSecondaryPressed);


                return true;
                //StartCommando();
            }

            return false;
        }

        private bool _r;
        protected override void ExecuteAction()
        {

            _r = StateController.WeaponModule.CheckIfAttackAvailable();
            
            if (!_r)
            {
                return;
            }

            StateController.AddTrigger(TriggersTemp.TriggerAim);
            /*if (!StateController.CurrentState.StateFlags.IsAiming)
            {
                
                StateController.Triggers.Add(TriggersTemp.TriggerAim);
            }*/
            
        }
        protected override bool ContinueCommandoCheck()
        {
            return _r;
        }

    }
}
