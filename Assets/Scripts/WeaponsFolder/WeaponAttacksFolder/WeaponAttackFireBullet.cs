using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackFireBullet:WeaponAttackBase
    {
        public override bool Predicate(WeaponBase weaponBase)
        {
            Debug.Log("PRED");
            if (weaponBase.IsPrimaryPressed)
            {
                return true;
            }
            return false;
        }


        

        public override void ExecuteAttack()
        {
            Debug.Log("FIRE");
        }
    }
}
