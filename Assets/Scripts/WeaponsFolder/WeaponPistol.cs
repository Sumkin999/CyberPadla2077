using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    [System.Serializable]
    public class WeaponPistol:WeaponBase
    {
        public WeaponPistol(WeaponMethodsHolder weaponMethodsHolder):base(weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;

            //WeaponVisuals = new WeaponVisuals();
        }

        public override void WeaponSelectedAction()
        {
            WeaponMethodsHolder.SetAnimatorWeaponSelected();
            Debug.Log("Pistol Selected!");
        }

        public override void WeaponDeselectedAction()
        {
            WeaponMethodsHolder.SetAnimatorWeaponDeSelected();
            Debug.Log("Pistol Hided!");
        }
    }
}
