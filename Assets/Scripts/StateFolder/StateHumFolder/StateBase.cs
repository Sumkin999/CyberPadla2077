using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.ComandFolder.Commands;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateHumFolder
{

    public class StateBase
    {
        public class StateFlagsClass
        {
            public bool CanMove { get;  protected internal set; }
            public bool IsMoving { get; protected internal set; }
            public bool IsAiming { get; protected internal set; }
        }
        public StateController StateController;
        public List<ComandDataBase> CommandDataToProcessList=new List<ComandDataBase>();
        protected List<Command> CommandsInState=new List<Command>();
        public StateFlagsClass StateFlags=new StateFlagsClass();

        public void AddCommandData(ComandDataBase comandData)
        {
            CommandDataToProcessList.Add(comandData);
        }

        public virtual void StateEnterAction()
        {
            
        }

        public virtual void StateExitAction(StateBase nextState)
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
            ComandDataAim comandDataAim=comandData as ComandDataAim;
            if (comandDataAim!=null)
            {
                foreach (var command in CommandsInState)
                {
                    if (command is ComandAim)
                    {
                        command.GetInputData(comandData);
 
                        return;
                    }
                }
            }
            ComandDataSelectWeapon comandDataSelectWeapon=comandData as ComandDataSelectWeapon;
            if (comandDataSelectWeapon!=null)
            {
                foreach (var command in CommandsInState)
                {
                    if (command is ComandSelectWeapon)
                    {
                        command.GetInputData(comandData);

                        return;
                    }
                }
            }
            ComandDataRotate comandDataRotate=comandData as ComandDataRotate;
            if (comandDataRotate != null)
            {
                foreach (var command in CommandsInState)
                {
                    if (command is ComandRotate)
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

        public void StateFixedUpdateAction()
        {
            foreach (var command in CommandsInState)
            {
                command.FixedUpdateCommand();
            }
        }
    }
}
