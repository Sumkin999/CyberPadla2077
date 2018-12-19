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

        public bool IsShootOrReload { get;  set; }
        public bool IsPrimaryPressed { get;  set; }
        public bool IsSecondaryPressed { get;  set; }

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
        

        public WeaponAttackBase CurrentWeaponAttack;
        public bool TrySelectAttack()
        {
            foreach (var attack in PotencialAttacks)
            {
                if (attack.Predicate(this))
                {
                    CurrentWeaponAttack = attack;
                    return true;
                }
            }
            Debug.Log("No attack");
            CurrentWeaponAttack = null;
            return false;
        }

        
        public void WeaponUpdate()
        {
            if (CurrentWeaponAttack != null)
            {
                CurrentWeaponAttack.ExecuteAttack();
            }
        }

        public virtual void WeaponSetPressedFlags(bool prim,bool secondary)
        {
            IsPrimaryPressed = prim;
            IsSecondaryPressed = secondary;
            //Потом в любом случае в false in Update
        }

        
    }
}
