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
        public WeaponAttackFireBullet(WeaponModuleMethodsHolder weaponModuleMethodsHolder,WeaponMethodsHolder weaponMethodsHolder):base(weaponModuleMethodsHolder,weaponMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;
            WeaponMethodsHolder = weaponMethodsHolder;
        }
        public override bool Predicate(WeaponBase weaponBase)
        {

            if (weaponBase.IsPrimaryPressed)
            {
                return true;
            }
            return false;
        }


        private float _primatyPressedTimer;

        public override void ExecuteAttack()
        {
            _primatyPressedTimer += Time.deltaTime;

            if (_primatyPressedTimer>1f)
            {
                WeaponModuleMethodsHolder.SetShotAnimation();
                Debug.Log("FIRE");

                _primatyPressedTimer = 0;
            }
            
            
        }
    }
}
