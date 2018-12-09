using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    [System.Serializable]
    public class WeaponBase
    {
        private WeaponMethodsHolder _weaponMethodsHolder;
        public WeaponVisuals WeaponVisulasPrefab;

        public WeaponBase(WeaponMethodsHolder weaponMethodsHolder)
        {
            _weaponMethodsHolder = weaponMethodsHolder;

            WeaponVisuals=new WeaponVisuals();
        }
        public WeaponVisuals WeaponVisuals;

        public bool HasPrimary;
        public bool HasSecondary;

        public void WeaponUpdate()
        {
            
        }
    }
}
