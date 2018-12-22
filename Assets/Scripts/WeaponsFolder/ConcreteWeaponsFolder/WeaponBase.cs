using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.WeaponsFolder.ConcreteWeaponsFolder.WeaponMonoFolder;
using Assets.Scripts.WeaponsFolder.ScrObjectsWeapon;
using Assets.Scripts.WeaponsFolder.WeaponAttacksFolder;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    public enum EnumWeaponHoldType
    {
        Default,
        Shotgun
    }

    public enum EnumWeaponType
    {
        Fists,
        Pistol,
        Shotgun
    }

    public class WeaponMethodsHolder
    {
        private WeaponBase _weapon;
        public WeaponMethodsHolder(WeaponBase weaponBase)
        {
            _weapon = weaponBase;
        }

        public bool GetPrimary()
        {
            return _weapon.IsPrimaryPressed;
        }

        public bool GetSecondary()
        {
            return _weapon.IsSecondaryPressed;
        }
    }
    [System.Serializable]
    public class WeaponBase
    {
        public EnumWeaponType EnumWeaponType;

        protected WeaponMethodsHolder WeaponMethodsHolder;

        protected WeaponModuleMethodsHolder WeaponModuleMethodsHolder;
        public WeaponVisuals WeaponVisulasPrefab;

        public bool IsShootOrReload { get;  set; }
        public bool IsPrimaryPressed { get;  set; }
        public bool IsSecondaryPressed { get;  set; }

        public EnumWeaponHoldType EnumWeaponHoldType;

        public WeaponBase(WeaponModuleMethodsHolder weaponModuleMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            InstantiateMonoForThisWeapon();
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
                    
                    if (attack!=CurrentWeaponAttack)
                    {
                        if (CurrentWeaponAttack!=null)
                        {
                            CurrentWeaponAttack.NullingAction();
                        }
                    }
                    CurrentWeaponAttack = attack;
                    return true;
                }
            }
            if (CurrentWeaponAttack!=null)
            {
                CurrentWeaponAttack.NullingAction();
            }
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




        public void InstantiateMonoForThisWeapon()
        {
            if (EnumWeaponType==EnumWeaponType.Pistol)
            {
                WeaponPistol weaponPistol=this as WeaponPistol;
                if (weaponPistol==null)
                {
                    return;
                }

                ScrObjWeaponPistol scrObjWeaponPistol=WeaponModuleMethodsHolder.GetScriptableObkect(EnumWeaponType) as ScrObjWeaponPistol;

                if (scrObjWeaponPistol==null)
                {
                    return;
                }

                GameObject pistolGameObject =
                GameObject.Instantiate(scrObjWeaponPistol.VisualPrefab,
                    WeaponModuleMethodsHolder.RightHandTransform.position, Quaternion.identity);

                pistolGameObject.transform.parent = WeaponModuleMethodsHolder.RightHandTransform;
                pistolGameObject.transform.localPosition = new Vector3(0, .0015f, .0005f);
                pistolGameObject.transform.localEulerAngles = new Vector3(-12.5f, 265, -190);

                weaponPistol.WeaponPistolMono = pistolGameObject.GetComponent<WeaponPistolMono>();

                pistolGameObject.SetActive(false);
            }
        }

        
    }
}
