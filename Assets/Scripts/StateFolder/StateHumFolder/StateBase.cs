using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateHumFolder
{
    public class StateBase
    {
        public StateController StateController;
        public List<Command> Commands=new List<Command>();

        public virtual void ProcessData(ComandDataBase comandData)
        {

            ComandDataMove comandDataMove=comandData as ComandDataMove;
            if (comandDataMove!=null)
            {

                foreach (var command in Commands)
                {
                    if (command is CommandMove)
                    {

                        command.GetInputData(comandData);
                        return;
                    }
                }
            }
        }
    }
}
