using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    public class WeaponUzi: WeaponBase
    {
        public WeaponUzi(WeaponMethodsHolder weaponMethodsHolder):base(weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;

            //WeaponVisuals = new WeaponVisuals();
        }


        public override void WeaponSelectedAction()
        {
            WeaponMethodsHolder.SetAnimatorWeaponSelected(this);
            Debug.Log("Uzi Selected!");
        }

        public override void WeaponDeselectedAction()
        {
            WeaponMethodsHolder.SetAnimatorWeaponDeSelected(this);
            Debug.Log("Uzi Hided!");
        }


    }
}
