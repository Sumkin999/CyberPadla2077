using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    [Serializable]
    public class WeaponFist:WeaponBase
    {
        public WeaponFist(WeaponMethodsHolder weaponMethodsHolder):base(weaponMethodsHolder)
        {
            WeaponMethodsHolder = weaponMethodsHolder;

            //WeaponVisuals = new WeaponVisuals();



        }

        public override void WeaponSelectedAction()
        {
            Debug.Log("Fist Selected!");
        }

        public override void WeaponDeselectedAction()
        {
            Debug.Log("Fist Hided!");
        }
    }
}
