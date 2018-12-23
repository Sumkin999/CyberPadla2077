using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.BrainFolder
{
    public class FallDataSender
    {
        public void SendFallComand(IFacade facadeI,Rigidbody rigidbody)
        {
            ComandDataFall cmf = new ComandDataFall();

            cmf.HumanRigidbody = rigidbody;

            facadeI.ComandGet(cmf);
        }
    }
}
