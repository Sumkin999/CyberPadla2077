using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WeaponsFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class WeaponModule:MonoBehaviour
    {
        public WeaponBase CurrentWeapon;

        public List<WeaponBase> InventoryWeapon=new List<WeaponBase>();
    }
}
