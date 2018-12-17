using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.BrainFolder
{
    public class RotateDataSender
    {
        public void SendRotateComand(IFacade facadeI, Vector3 vec)
        {
            ComandDataRotate cmm = new ComandDataRotate();
            cmm.LookAtVector3 = vec;

            facadeI.ComandGet(cmm);
        }
    }
}
