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
        private bool _hasAttack;
        public override void GetInputData(ComandDataBase comandData)
        {
            ComandDataAim comandDataAim=comandData as ComandDataAim;
            if (comandDataAim!=null)
            {
                if (comandDataAim.IsPrimaryPressed)
                {
                    
                    StateController.WeaponModule.PrimaryNotify();
                }
                
            }
            _hasAttack = StateController.WeaponModule.AttackStateCheck;

        }

        protected override bool StartConditionCheck()
        {
            if (!_hasAttack)
            {
                return false;
            }   
            return true;
        }
        protected override void PrepareCommandoAction()
        {
            
            if (!StateController.CurrentState.StateFlags.IsAiming)
            {
                
                StateController.Triggers.Add(TriggersTemp.TriggerAim);
            }
            
        }

    }
}
