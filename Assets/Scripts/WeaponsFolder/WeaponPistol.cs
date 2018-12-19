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
    public class WeaponPistol:WeaponBase
    {
        public WeaponPistol(WeaponMethodsHolder weaponMethodsHolder):base(weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;

            PotencialAttacks.Add(new WeaponAttackFireBullet());
            //WeaponVisuals = new WeaponVisuals();
        }

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
            WeaponMethodsHolder.SetAnimatorWeaponSelected(this);
            Debug.Log("Pistol Selected!");
        }

        public override void WeaponDeselectedAction()
        {
            WeaponMethodsHolder.SetAnimatorWeaponDeSelected(this);
            Debug.Log("Pistol Hided!");
        }

        
    }
}
