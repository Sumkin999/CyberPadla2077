using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WeaponsFolder;
using Assets.Scripts.WeaponsFolder.ConcreteWeaponsFolder.WeaponMonoFolder;
using Assets.Scripts.WeaponsFolder.ScrObjectsWeapon;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    /*
     Для взаимодействия оружия и атаки с дугими модулями!!!
         (В основном с AnimatorModule)
         */
    public class WeaponModuleMethodsHolder
    {
        private FacadeHumanMono _facadeHuman;
        public Transform RightHandTransform;
        
        public WeaponModuleMethodsHolder(FacadeHumanMono facadeHuman,Transform rightHandTransform)
        {
            _facadeHuman = facadeHuman;
            RightHandTransform = rightHandTransform;
        }

        public void SetShotAnimation()
        {
            _facadeHuman.AnimatorModule.Animator.SetTrigger("ShotTrigger");
        }

        public virtual void SetAnimatorWeaponSelected(WeaponBase weaponBase)
        {
            _facadeHuman.AnimatorModule.ToggleWeaponHold(weaponBase);
        }
        public virtual void SetAnimatorWeaponDeSelected()
        {
            _facadeHuman.AnimatorModule.ToggleNoWeaponHold();
        }

        public ScrObjWeaponBase GetScriptableObkect(EnumWeaponType enumWeaponType)
        {
            Debug.Log("aaa");
            if (enumWeaponType==EnumWeaponType.Pistol)
            {
                Debug.Log("Return");
                return _facadeHuman.WeaponModule.ScrObjWeaponPistol;
            }

            return null;
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
            _weaponModuleMethodsHolder=new WeaponModuleMethodsHolder(_facadeHuman,RightHandTransform);
        }

        protected List<WeaponBase> InventoryWeapon=new List<WeaponBase>();

        private WeaponModuleMethodsHolder _weaponModuleMethodsHolder;

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
            InventoryWeapon.Add((T)Activator.CreateInstance(typeof(T), _weaponModuleMethodsHolder)); //new T(_weaponMethodsHolder));
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
            if (InventoryWeapon.Count <= 1)
            {
                return;
            }
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


        public void WeaponModuleShootWeapon()
        {
            if (CurrentWeapon==null)
            {
                return;
            }
            WeaponPistol weaponPistol=CurrentWeapon as WeaponPistol;
            if (weaponPistol==null)
            {
                return;
            }
            weaponPistol.WeaponPistolMono.ShowMuzzle();
            Debug.Log("Actual Fire!");

            Ray ray = new Ray(RightHandTransform.position,
                _facadeHuman.TransformModule.MainTransform.forward);

            Debug.DrawRay(RightHandTransform.position,
                _facadeHuman.TransformModule.MainTransform.forward*100f);

            //hits = Physics.RaycastAll(ray,
            //    100.0F, layerMask, queryTriggerInteraction);


        }

        




    }
}
