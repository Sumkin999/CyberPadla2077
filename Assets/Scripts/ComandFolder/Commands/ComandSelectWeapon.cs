using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandSelectWeapon:Command
    {
        protected override bool StartConditionCheck()
        {
            
            if (StateController.WeaponModule.InventoryWeapon.Count>1)
            {
                Debug.Log("Has more guns");
                return true;
            }
            return false;
        }
        protected override void PrepareCommandoAction()
        {
            StateController.WeaponModule.CurrentWeapon.WeaponDeselectedAction();

            int index = StateController.WeaponModule.InventoryWeapon.IndexOf(StateController.WeaponModule.CurrentWeapon);
            index++;
            if (index>= StateController.WeaponModule.InventoryWeapon.Count)
            {
                index = 0;
            }
            StateController.WeaponModule.CurrentWeapon = StateController.WeaponModule.InventoryWeapon[index];
            StateController.WeaponModule.CurrentWeapon.WeaponSelectedAction();


        }
        protected override bool ContinueCommandoCheck()
        {
            return false;
        }
    }
}
