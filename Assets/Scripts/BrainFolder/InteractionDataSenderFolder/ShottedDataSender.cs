using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData.InteractionComandDataFolder;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.BrainFolder.InteractionDataSenderFolder
{
    public class ShottedDataSender
    {
        public void ShottedComand(IFacade facadeI)
        {
            ComandInDataShotted cshottd = new ComandInDataShotted();
            //cmm.LookAtVector3 = vec;

            facadeI.ComandGet(cshottd);
        }
    }
}
