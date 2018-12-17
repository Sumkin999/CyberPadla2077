using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandAttack:Command
    {
        
        public override void GetInputData(ComandDataBase comandData)
        {
            ComandDataAttack comandDataAttack=comandData as ComandDataAttack;
            if (comandDataAttack!=null)
            {
                if (comandDataAttack.IsPrimaryPressed)
                {

                    StateController.WeaponModule.PrimaryNotify();
                }
            }

        }
        protected override bool StartConditionCheck()
        {
           
            return true;
        }

        protected override void ExecuteAction()
        {
            StateController.WeaponModule.CurrentWeapon.WeaponUpdate();
            StateController.WeaponModule.CurrentWeapon.WeaponAnyStateUpdate();
            StateController.WeaponModule.CurrentWeapon.WeaponAttackStateUpdate();
        }

        protected override bool ContinueCommandoCheck()
        {
            if (StateController.WeaponModule.AttackStateCheck)
            {
                return true;
            }
            return false;
        }




    }
}
