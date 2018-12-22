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
        protected override void GetInputData(ComandDataBase comandData)
        {
            
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
