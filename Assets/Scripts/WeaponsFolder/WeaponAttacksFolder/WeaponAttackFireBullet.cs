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
        public WeaponAttackFireBullet(WeaponMethodsHolder weaponMethodsHolder):base(weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;
        }
        public override bool Predicate(WeaponBase weaponBase)
        {
            Debug.Log("PRED");
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
                WeaponMethodsHolder.SetShotAnimation();
                Debug.Log("FIRE");

                _primatyPressedTimer = 0;
            }
            
            
        }
    }
}
