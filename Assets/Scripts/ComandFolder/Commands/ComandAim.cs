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
        
        public override void GetInputData(ComandDataBase comandData)
        {
            ComandDataAim comandDataAim=comandData as ComandDataAim;
            if (comandDataAim!=null)
            {
                
                StateController.WeaponModule.AttempToAttackNotify(comandDataAim.IsPrimaryPressed,comandDataAim.IsSecondaryPressed);

                StartCommando();
            }
            

        }

        private bool _r;
        protected override void ExecuteAction()
        {

            _r = StateController.WeaponModule.CheckIfAttackAvailable();
            
            if (!_r)
            {
                return;
            }
            if (!StateController.CurrentState.StateFlags.IsAiming)
            {
                
                StateController.Triggers.Add(TriggersTemp.TriggerAim);
            }
            
        }
        protected override bool ContinueCommandoCheck()
        {
            return _r;
        }

    }
}
