using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.BrainFolder.InteractionDataSenderFolder;
using Assets.Scripts.ComandFolder.ComandData;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules.HumanInteractionFolder
{
    public class ColliderHumanPart:MonoBehaviour
    {
        public IFacade IfFacade;
        protected ShottedDataSender ShottedDataSender = new ShottedDataSender();

        public void Foo()
        {
            ShottedDataSender.ShottedComand(IfFacade);
           // IfFacade.ComandGet(new ComandDataFall());
        }
    }
}
