using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WeaponsFolder;
using Assets.Scripts.WeaponsFolder.ScrObjectsWeapon;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class WeaponMethodsHolder
    {
        private FacadeHumanMono _facadeHuman;
        private Transform _rightHandTransform;
        public WeaponMethodsHolder(FacadeHumanMono facadeHuman,Transform rightHandTransform)
        {
            _facadeHuman = facadeHuman;
            _rightHandTransform = rightHandTransform;
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

        public void SpawnPistolAtRightHand()
        {
            GameObject pistolGameObject =
                GameObject.Instantiate(_facadeHuman.WeaponModule.ScrObjWeaponPistol.VisualPrefab,
                    _facadeHuman.WeaponModule.RightHandTransform.position, Quaternion.identity);

            pistolGameObject.transform.parent = _facadeHuman.WeaponModule.RightHandTransform;
        }
    }
    public class WeaponModule:MonoBehaviour
    {
        
        public ScrObjWeaponPistol ScrObjWeaponPistol;
        protected WeaponBase CurrentWeapon;

        private FacadeHumanMono _facadeHuman;

        public void SetFacade(FacadeHumanMono facadeHumanMono)
        {
            _facadeHuman = facadeHumanMono;
            _weaponMethodsHolder=new WeaponMethodsHolder(_facadeHuman,RightHandTransform);
        }

        public List<WeaponBase> InventoryWeapon=new List<WeaponBase>();

        private WeaponMethodsHolder _weaponMethodsHolder;

        public Transform RightHandTransform;

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
            CurrentWeaponExecuteAttack();
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

        

        public void CurrentWeaponExecuteAttack()
        {
            if (CurrentWeapon == null)
            {
                return;
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
