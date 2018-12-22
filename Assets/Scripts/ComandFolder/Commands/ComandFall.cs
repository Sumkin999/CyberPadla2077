using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandFall:Command
    {
        protected override void GetInputData(ComandDataBase comandData)
        {
            ComandDataFall comandDatafall = comandData as ComandDataFall;
            if (comandDatafall != null)
            {
                
            }
        }


        protected override void PrepareCommandoAction()
        {
            StateController.Triggers.Add(TriggersTemp.TriggerFall);

        }
    }
}
