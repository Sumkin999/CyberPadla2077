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
        public WeaponUzi(WeaponModuleMethodsHolder weaponModuleMethodsHolder):base(weaponModuleMethodsHolder)
        {
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            //WeaponVisuals = new WeaponVisuals();

            EnumWeaponHoldType=EnumWeaponHoldType.Shotgun;
        }


        public override void WeaponSelectedAction()
        {
            WeaponModuleMethodsHolder.SetAnimatorWeaponSelected(this);
            Debug.Log("Uzi Selected!");
        }

        public override void WeaponDeselectedAction()
        {
            WeaponModuleMethodsHolder.SetAnimatorWeaponDeSelected();
            Debug.Log("Uzi Hided!");
        }


    }
}
