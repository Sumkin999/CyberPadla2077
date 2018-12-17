using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.ScrObjectsWeapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/WeaponFist")]
    [System.Serializable]
    //public class ScrObjWeapon : ScriptableObject 
    public class ScrObjWeaponFist:ScriptableObject 
    {
        public GameObject VisualPrefab;
        //
        [SerializeField]
        public WeaponFist classes;



        //[SerializeField]
        //public object classesSS;
    }

    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/WeaponPistol")]
    [System.Serializable]
    //public class ScrObjWeapon : ScriptableObject 
    public class ScrObjWeaponPistol : ScriptableObject
    {
        public GameObject VisualPrefab;
        //
        [SerializeField]
        public WeaponPistol classes;



        //[SerializeField]
        //public object classesSS;
    }

    [CreateAssetMenu(fileName = "WeaponUzi", menuName = "Weapons/WeaponUzi")]
    [System.Serializable]
    //public class ScrObjWeapon : ScriptableObject 
    public class ScrObjWeaponUzi : ScriptableObject
    {
        public GameObject VisualPrefab;
        //
        [SerializeField]
        public WeaponPistol classes;



        //[SerializeField]
        //public object classesSS;
    }

}
