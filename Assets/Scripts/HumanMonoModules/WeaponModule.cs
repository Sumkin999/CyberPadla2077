using System;
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

        public virtual void SetAnimatorWeaponSelected()
        {
            Debug.Log("WeaponSelected!");
            _facadeHuman.AnimatorModule.ToggleAim(true);
        }
        public virtual void SetAnimatorWeaponDeSelected()
        {
            Debug.Log("WeaponDeSelected!");
            _facadeHuman.AnimatorModule.ToggleAim(false);
        }
    }
    public class WeaponModule:MonoBehaviour
    {
        
        public WeaponBase CurrentWeapon;

        private FacadeHumanMono _facadeHuman;

        public void SetFacade(FacadeHumanMono facadeHumanMono)
        {
            _facadeHuman = facadeHumanMono;
            _weaponMethodsHolder=new WeaponMethodsHolder(_facadeHuman);
        }

        public List<WeaponBase> InventoryWeapon=new List<WeaponBase>();

        private WeaponMethodsHolder _weaponMethodsHolder;
        public void SpawnWeapon<T>() where  T:WeaponBase//,new()
        {
            InventoryWeapon.Add((T)Activator.CreateInstance(typeof(T), _weaponMethodsHolder)); //new T(_weaponMethodsHolder));
        }

        
    }
}
