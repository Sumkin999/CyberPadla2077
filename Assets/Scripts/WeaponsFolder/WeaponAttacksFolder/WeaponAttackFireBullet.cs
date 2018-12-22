using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackFireBullet:WeaponAttackBase
    {
        private IWeaponHasTimers _iWeaponHasTimers;
        private IWeaponHasMuzzle _iweaponHasMuzzle;
        public WeaponAttackFireBullet(WeaponModuleMethodsHolder weaponModuleMethodsHolder,IWeaponHasTimers iWeaponHasTimers,IWeaponHasMuzzle iWeaponHasMuzzle ):base(weaponModuleMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;
            _iWeaponHasTimers = iWeaponHasTimers;
            _iweaponHasMuzzle = iWeaponHasMuzzle;
        }
        public override bool Predicate(WeaponBase weaponBase)
        {

            if (weaponBase.IsPrimaryPressed)
            {
                return true;
            }
            return false;
        }


      

        public override void ExecuteAttack()
        {
            

            if (_iWeaponHasTimers.PrimaryPressedTimer>1f)
            {
                WeaponModuleMethodsHolder.SetShotAnimation();
                Debug.Log("FIRE");
                _iweaponHasMuzzle.CreateMuzzle();

                _iWeaponHasTimers.PrimaryPressedTimer = 0;
            }
            
            
        }
    }
}
