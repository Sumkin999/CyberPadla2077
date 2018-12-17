using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackFireBullet:WeaponAttackBase
    {
        public override bool Predicate(WeaponBase weaponBase)
        {
            if (weaponBase.IsPrimaryPressed)
            {
                return true;
            }
            return false;
        }

        public override void AttackStateUpdateAction()
        {

        }

        public override void AnyStateUpdateAction()
        {

        }
    }
}
