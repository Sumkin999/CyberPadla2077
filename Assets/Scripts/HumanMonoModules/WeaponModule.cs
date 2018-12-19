using System;
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
            _facadeHuman.AnimatorModule.Animator.SetTrigger("ShotTrigger");
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

        public void ModuleUpdateAction()
        {
            CurrentWeaponAttackAnyStateUpdateAction();
            UnSetPressedFlags();
            
        }
        public void SpawnWeapon<T>() where  T:WeaponBase//,new()
        {
            InventoryWeapon.Add((T)Activator.CreateInstance(typeof(T), _weaponMethodsHolder)); //new T(_weaponMethodsHolder));
        }

        public bool CheckIfAttackAvailable()
        {
            if (CurrentWeapon==null)
            {
                return false;
            }
            
            CurrentWeapon.TrySelectAttack();
            
            if (CurrentWeapon.CurrentWeaponAttack==null)
            {
                
                return false;
            }
            return true;
        }

       

        public void  SetPressedFlags(bool isPrimaryPressed,bool isSecondaryPressed)
        {

            CurrentWeapon.WeaponSetPressedFlags(isPrimaryPressed,isSecondaryPressed);
            
        }

        public void UnSetPressedFlags()
        {
            if (CurrentWeapon!=null)
            {
                CurrentWeapon.IsPrimaryPressed = false;
                CurrentWeapon.IsSecondaryPressed = false;
            }
        }

        

        public void CurrentWeaponAttackAnyStateUpdateAction()
        {
            if (CurrentWeapon == null)
            {
                return;
            }
            if (CurrentWeapon.IsPrimaryPressed)
            {
                Debug.Log("PRIMARY PRESSED");
            }
            else
            {
                Debug.Log("NOT PPRESSED");
            }
            if (CurrentWeapon.IsSecondaryPressed)
            {
                Debug.Log("SECONDARY PRESSED");
            }
            else
            {
                Debug.Log("NOT SPRESSED");
            }
            CurrentWeapon.WeaponUpdate();
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
