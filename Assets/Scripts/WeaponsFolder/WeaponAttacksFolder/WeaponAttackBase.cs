using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackBase
    {
        public WeaponAttackBase(WeaponModuleMethodsHolder weaponModuleMethodsHolder,WeaponMethodsHolder weaponMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;
            WeaponMethodsHolder = weaponMethodsHolder;
        }
        protected WeaponModuleMethodsHolder WeaponModuleMethodsHolder;
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
