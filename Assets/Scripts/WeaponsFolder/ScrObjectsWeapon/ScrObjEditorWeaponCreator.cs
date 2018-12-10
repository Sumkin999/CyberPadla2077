using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Animations;
using UnityEditor;
#endif

namespace Assets.Scripts.WeaponsFolder.ScrObjectsWeapon
{
    public enum WeaponCreateType
    {
        Fists,
        Pistols
    }
    [CreateAssetMenu(fileName = "WeaponCreator", menuName = "Weapons/WeaponCreator", order = 1)]
    public class ScrObjEditorWeaponCreator:ScriptableObject
    {
#if UNITY_EDITOR

        
        public WeaponCreateType WeaponCreateType;

        //private ScrObjWeapon<T> scrObjWeapon;
        private WeaponMethodsHolder _wmh;


        public void Create()
        {
            string strFolder = "Assets/Weapons";

            

            

            //scrObjWeapon = ScriptableObjectUtility.CreateAsset<ScrObjWeapon>(strFolder, "Weapon");

            if (WeaponCreateType==WeaponCreateType.Fists)
            {
                //scrObjWeapon.classes=new WeaponFist(_wmh);
                //scrObjWeapon = 
                ScriptableObjectUtility.CreateAsset<ScrObjWeaponFist>(strFolder, "WeaponFist");
            }
            else
            {
                ScriptableObjectUtility.CreateAsset<ScrObjWeaponPistol>(strFolder, "WeaponPistol");
                //scrObjWeapon.classes=new WeaponPistol(_wmh);

            }
        }

#endif
    }
}
