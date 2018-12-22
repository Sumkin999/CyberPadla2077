using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.WeaponsFolder.ConcreteWeaponsFolder.WeaponMonoFolder;
using Assets.Scripts.WeaponsFolder.WeaponAttacksFolder;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    [System.Serializable]
    public class WeaponPistol:WeaponBase,IWeaponHasTimers,IWeaponHasMuzzle
    {
        public WeaponPistol(WeaponModuleMethodsHolder weaponModuleMethodsHolder):base(weaponModuleMethodsHolder)
        {
            EnumWeaponType=EnumWeaponType.Pistol;



            InstantiateMonoForThisWeapon();
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            PotencialAttacks.Add(new WeaponAttackFireBullet(WeaponModuleMethodsHolder,this,this));


        }

        public WeaponPistolMono WeaponPistolMono;
        private float _primatyPressedTimer;
        private float _secondaryPressedTimer;

        public float PrimaryPressedTimer
        {
            get { return _primatyPressedTimer; }

            set { _primatyPressedTimer = value; }
        }

        public float SecondaryPressedTimer
        {
            get { return _secondaryPressedTimer; }

            set { _secondaryPressedTimer = value; }
        }

        public override void AdditionalUpdateAction()//WeaponSetPressedFlags(bool prim, bool secondary)
        {
            
            if (IsPrimaryPressed && _primatyPressedTimer<1f)
            {
                _primatyPressedTimer += Time.deltaTime ;
            }
            if (IsSecondaryPressed && _secondaryPressedTimer<1f)
            {
                _secondaryPressedTimer += Time.deltaTime ;
            }
            
        }

        public override void WeaponSelectedAction()
        {
           WeaponPistolMono.gameObject.SetActive(true);
        }

        public override void WeaponDeselectedAction()
        {
            WeaponPistolMono.gameObject.SetActive(false);
        }

        public void CreateMuzzle()
        {
            WeaponPistolMono.ShowMuzzle();
        }
    }
}
