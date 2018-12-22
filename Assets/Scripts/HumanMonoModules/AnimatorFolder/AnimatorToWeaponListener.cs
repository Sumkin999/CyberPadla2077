using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules.AnimatorFolder
{
    public class AnimatorToWeaponListener:MonoBehaviour
    {
        private WeaponModule _weaponModule;


        public void SetModules(WeaponModule weaponModule)
        {
            _weaponModule = weaponModule;
            
        }



        public void EventShotted()
        {
            _weaponModule.WeaponModuleShootWeapon();
        }
        
    }
}
