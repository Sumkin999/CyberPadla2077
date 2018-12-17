﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.WeaponsFolder.WeaponAttacksFolder;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    [System.Serializable]
    public class WeaponBase
    {
        protected WeaponMethodsHolder WeaponMethodsHolder;
        public WeaponVisuals WeaponVisulasPrefab;

        public bool IsShootOrReload { get; protected set; }

        public WeaponBase(WeaponMethodsHolder weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;

            //WeaponVisuals=new WeaponVisuals();
        }
        public WeaponVisuals WeaponVisuals;

        

        public List<WeaponAttackBase> PotencialAttacks=new List<WeaponAttackBase>();

        public virtual void WeaponSelectedAction()
        {
            
        }

        public virtual void WeaponDeselectedAction()
        {
            
        }
        public virtual void WeaponUpdate()
        {
            
        }

        public WeaponAttackBase CurrentWeaponAttack;
        public WeaponAttackBase TrySelectAttack()
        {
            foreach (var attack in PotencialAttacks)
            {
                if (attack.Predicate(this))
                {
                    return attack;
                }
            }
            return null;
        }

        public void WeaponAttackStateUpdate()
        {
            if (CurrentWeaponAttack!=null)
            {
                CurrentWeaponAttack.AttackStateUpdateAction();
            }
        }
        public void WeaponAnyStateUpdate()
        {
            if (CurrentWeaponAttack != null)
            {
                CurrentWeaponAttack.AnyStateUpdateAction();
            }
        }
    }
}
