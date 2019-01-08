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
        protected override bool GetInputData(ComandDataBase comandData)
        {
            ComandDataSelectWeapon cdsm=comandData as ComandDataSelectWeapon;

            if (cdsm != null)
            {
                return true;
            }

            return false;
        }
        
        protected override void PrepareCommandoAction()
        {
            StateController.WeaponModule.SelectNextWeapon();

            


        }
        protected override bool ContinueCommandoCheck()
        {
            return false;
        }
    }
}
