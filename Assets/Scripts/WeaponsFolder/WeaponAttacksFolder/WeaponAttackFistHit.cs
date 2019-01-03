using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackFistHit: WeaponAttackBase
    {
        private WeaponFist _weaponFist;
        public WeaponAttackFistHit(WeaponModuleMethodsHolder weaponModuleMethodsHolder):base(weaponModuleMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            
        }

        public override bool Predicate(WeaponBase weaponBase)
        {
            if(_weaponFist==null)
                _weaponFist=weaponBase as WeaponFist;
            if (_weaponFist == null)
            {
                return false;
            }
            if (weaponBase.IsPrimaryPressed && _weaponFist.HitTimerCurrent<=.2f)
            {
                return true;
            }
            return false;
        }

        public override void ExecuteAttack()
        {


            
            WeaponModuleMethodsHolder.SetFistAnimation();
            _weaponFist.HitTimerCurrent = 2f;




        }
    }
}
