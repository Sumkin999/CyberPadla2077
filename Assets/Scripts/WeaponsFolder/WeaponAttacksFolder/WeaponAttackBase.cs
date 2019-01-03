﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.WeaponAttacksFolder
{
    public class WeaponAttackBase
    {
        public WeaponAttackBase(WeaponModuleMethodsHolder weaponModuleMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;
            
        }
        protected WeaponModuleMethodsHolder WeaponModuleMethodsHolder;
        

        public virtual void NullingAction()
        {
            Debug.Log("N!");
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
