using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandAim:Command
    {
       
        public override void GetInputData(ComandDataBase comandData)
        {
           

        }

        protected override bool StartConditionCheck()
        {
            return true;
        }
        protected override void PrepareCommandoAction()
        {
            
            if (!StateController.CurrentState.StateFlags.IsAiming)
            {
                
                StateController.Triggers.Add(TriggersTemp.TriggerAim);
            }
            
        }

    }
}
