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

    public interface IWeaponHasTimers
    {
        float PrimaryPressedTimer { get; set; }
        float SecondaryPressedTimer { get; set; }
    }

    public interface IWeaponHasMuzzle
    {
        void CreateMuzzle();
    }
    
    [System.Serializable]
    public class WeaponBase
    {
        public EnumWeaponType EnumWeaponType;

        

        protected WeaponModuleMethodsHolder WeaponModuleMethodsHolder;
        public WeaponMonoVisuals WeaponMonoVisulasPrefab;

        public bool IsShootOrReload { get;  set; }
        public bool IsPrimaryPressed { get;  set; }
        public bool IsSecondaryPressed { get;  set; }

        public EnumWeaponHoldType EnumWeaponHoldType;

        public WeaponBase(WeaponModuleMethodsHolder weaponModuleMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            InstantiateMonoForThisWeapon();
        }
        public WeaponMonoVisuals WeaponMonoVisuals;

        

        protected List<WeaponAttackBase> PotencialAttacks=new List<WeaponAttackBase>();

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
            AdditionalUpdateAction();
            if (CurrentWeaponAttack != null)
            {
                CurrentWeaponAttack.ExecuteAttack();
            }
            
        }

        public virtual void AdditionalUpdateAction()
        {
            
        }

        public  void WeaponSetPressedFlags(bool prim,bool secondary)
        {
            IsPrimaryPressed = prim;
            IsSecondaryPressed = secondary;
            
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
