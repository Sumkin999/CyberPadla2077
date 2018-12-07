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
        public List<ComandDataBase> CommandDataToProcessList=new List<ComandDataBase>();
        protected List<Command> CommandsInState=new List<Command>();

        public void AddCommandData(ComandDataBase comandData)
        {
            CommandDataToProcessList.Add(comandData);
        }

        public virtual void StateEnterAction()
        {
            
        }

        protected virtual void ProcessSingleData(ComandDataBase comandData)
        {
            ComandDataMove comandDataMove=comandData as ComandDataMove;
            if (comandDataMove!=null)
            {
                foreach (var command in CommandsInState)
                {
                    if (command is CommandMove)
                    {
                        command.GetInputData(comandData);
                        return;
                    }
                }
            }
        }

        public  void StateUpdateAction()
        {
            Debug.Log(this);
            foreach (var commandData in CommandDataToProcessList)
            {
                if (!commandData.IsProcessed)
                {
                    ProcessSingleData(commandData);
                    commandData.Process();
                }  
            }
            if (CommandDataToProcessList.Count > 0)
            {
                for (int i = CommandDataToProcessList.Count - 1; i >= 0; i--)
                {        
                    if (CommandDataToProcessList[i].IsProcessed)
                    {
                        CommandDataToProcessList.RemoveAt(i);
                    }
                }
            }

            foreach (var command in CommandsInState)
            {
                command.UpdateCommand();
            }


        }
    }
}
