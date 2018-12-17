using System;
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
        public bool IsPrimaryPressed { get; private set; }

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
            NotPressedAction();
            return false;
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

        private void NotPressedAction()
        {
            
        }

        private void PressedAction()
        {
            IsPrimaryPressed = true;
        }
    }
}
