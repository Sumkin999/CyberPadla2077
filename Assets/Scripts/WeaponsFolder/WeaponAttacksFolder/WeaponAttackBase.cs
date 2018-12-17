using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackBase
    {
        public virtual bool Predicate(WeaponBase weaponBase)
        {
            return false;
        }

        public virtual void AttackStateUpdateAction()
        {
            
        }

        public virtual void AnyStateUpdateAction()
        {
            
        }
    }
}
