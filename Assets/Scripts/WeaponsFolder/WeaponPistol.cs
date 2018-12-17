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

        public int In;
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
