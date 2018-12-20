using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackBase
    {
        public WeaponAttackBase(WeaponMethodsHolder weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;
        }
        protected WeaponMethodsHolder WeaponMethodsHolder;

        public virtual void NullingAction()
        {
            
        }

        public virtual bool Predicate(WeaponBase weaponBase)
        {
            return false;
        }

       

        public virtual void ExecuteAttack()
        {
            
        }
    }
}
