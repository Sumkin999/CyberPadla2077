using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.ScrObjectsWeapon
{
    public class ScrObjWeaponBase : ScriptableObject
    {
        public GameObject VisualPrefab;
        
    }
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/WeaponFist")]
    [System.Serializable]

    public class ScrObjWeaponFist: ScrObjWeaponBase
    {

        [SerializeField]
        public WeaponFist classes;

    }

    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/WeaponPistol")]
    [System.Serializable]

    public class ScrObjWeaponPistol : ScrObjWeaponBase
    {

        [SerializeField]
        public WeaponPistol classes;

    }

    [CreateAssetMenu(fileName = "WeaponUzi", menuName = "Weapons/WeaponUzi")]
    [System.Serializable] 
    public class ScrObjWeaponUzi : ScrObjWeaponBase
    {

        [SerializeField]
        public WeaponPistol classes;
    }

}
