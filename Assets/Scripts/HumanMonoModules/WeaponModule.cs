﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WeaponsFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class WeaponMethodsHolder
    {
        private FacadeHumanMono _facadeHuman;
        public WeaponMethodsHolder(FacadeHumanMono facadeHuman)
        {
            _facadeHuman = facadeHuman;
        }
        public void SetShotAnimation()
        {

        }

        public virtual void SetAnimatorWeaponSelected(WeaponBase weaponBase)
        {
            _facadeHuman.AnimatorModule.ToggleAim(true,weaponBase);
        }
        public virtual void SetAnimatorWeaponDeSelected(WeaponBase weaponBase)
        {
            _facadeHuman.AnimatorModule.ToggleAim(false,weaponBase);
        }
    }
    public class WeaponModule:MonoBehaviour
    {
        
        protected WeaponBase CurrentWeapon;

        private FacadeHumanMono _facadeHuman;

        public void SetFacade(FacadeHumanMono facadeHumanMono)
        {
            _facadeHuman = facadeHumanMono;
            _weaponMethodsHolder=new WeaponMethodsHolder(_facadeHuman);
        }

        public List<WeaponBase> InventoryWeapon=new List<WeaponBase>();

        private WeaponMethodsHolder _weaponMethodsHolder;

        public void IniciateWeaponModule()
        {
            SpawnWeapon<WeaponFist>();
            SpawnWeapon<WeaponPistol>();
            SpawnWeapon<WeaponUzi>();


            CurrentWeapon = InventoryWeapon[0];
            CurrentWeapon.WeaponSelectedAction();
        }
        public void SpawnWeapon<T>() where  T:WeaponBase//,new()
        {
            InventoryWeapon.Add((T)Activator.CreateInstance(typeof(T), _weaponMethodsHolder)); //new T(_weaponMethodsHolder));
        }

        public bool CheckIfAttackAvailable()
        {
            if (CurrentWeapon.CurrentWeaponAttack==null)
            {
                CurrentWeapon.TrySelectAttack();
            }
            if (CurrentWeapon.CurrentWeaponAttack==null)
            {
                return false;
            }
            return true;
        }

       

        public void  AttempToAttackNotify(bool isPrimaryPressed,bool isSecondaryPressed)
        {

            CurrentWeapon.WeaponAttemptAttackNotify(isPrimaryPressed,isSecondaryPressed);

            //return CurrentWeapon.TrySelectAttack();
            
        }

        public void CurrentWeaponAttackStateUpdateAction()
        {
            if (CurrentWeapon==null)
            {
                return;
            }
            CurrentWeapon.WeaponAttackStateUpdate();
        }

        public void CurrentWeaponAttackAnyStateUpdateAction()
        {
            if (CurrentWeapon == null)
            {
                return;
            }
            CurrentWeapon.WeaponAnyStateUpdate();
        }

        public void CurrentWeaponDeselectedAction()
        {
            if (CurrentWeapon==null)
            {
                return;
            }
            CurrentWeapon.WeaponDeselectedAction();
        }

        public void CurrentWeaponSelectedAction()
        {
            if (CurrentWeapon == null)
            {
                return;
            }
            CurrentWeapon.WeaponSelectedAction();
        }

        public void SelectNextWeapon()
        {
            int index = 0;
            if (CurrentWeapon!=null)
            {
                CurrentWeapon.WeaponDeselectedAction();
                index = InventoryWeapon.IndexOf(CurrentWeapon);
                index++;
            }
             
            
            if (index >= InventoryWeapon.Count)
            {
                index = 0;
            }
            CurrentWeapon = InventoryWeapon[index];
            CurrentWeapon.WeaponSelectedAction();
        }

        




    }
}
