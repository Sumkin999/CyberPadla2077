using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.BrainFolder
{
    public class FallDataSender
    {
        public void SendFallComand(IFacade facadeI)
        {
            ComandDataFall cmf = new ComandDataFall();
            

            facadeI.ComandGet(cmf);
        }
    }
}
