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
    public class WeaponPistol:WeaponBase
    {
        public WeaponPistol(WeaponModuleMethodsHolder weaponModuleMethodsHolder):base(weaponModuleMethodsHolder)
        {
            EnumWeaponType=EnumWeaponType.Pistol;

            WeaponMethodsHolder = new WeaponMethodsHolder(this);

            InstantiateMonoForThisWeapon();
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            PotencialAttacks.Add(new WeaponAttackFireBullet(WeaponModuleMethodsHolder,WeaponMethodsHolder));


        }

        public WeaponPistolMono WeaponPistolMono;
        private float _primatyPressedTimer;
        private float _secondaryPressedTimer;

        public override void WeaponSetPressedFlags(bool prim, bool secondary)
        {
            IsPrimaryPressed = prim;
            IsSecondaryPressed = secondary;
            if (prim && _primatyPressedTimer<1f)
            {
                _primatyPressedTimer += Time.deltaTime * 2f;
            }
            if (secondary && _secondaryPressedTimer<1f)
            {
                _secondaryPressedTimer += Time.deltaTime * 2f;
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

        
    }
}
