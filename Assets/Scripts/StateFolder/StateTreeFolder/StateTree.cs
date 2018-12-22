using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;
using Assets.Scripts.StateFolder.StateTreeFolder.StateConnections;
using Assets.Scripts.StateFolder.StateTreeFolder.StateNodes;

namespace Assets.Scripts.StateFolder.StateTreeFolder
{
    public class StateTree
    {
        public StateTree(StateController stateController)
        {
            StateController = stateController;

            
        }

        public StateBase SetIdleStateAsCurrent()
        {
            StateBase stateIdle=Array.Find(Nodes,h=>h.State is StateIdle).State  ;
            if (stateIdle!=null)
            {
                return stateIdle;
            }
            else
            {
                return Nodes[0].State;
            }
        }
        public StateController StateController;

        

        public StateNode CurrentNode;//{ get; private set; }
        //public StateNode LastNode { get; private set; }

        public StateNode[] Nodes;
        public StateConnection[] Connections;

        /*public void NewStateTrigger(TriggersTemp triggersTemp)
        {
            if (StateController.CurrentState is StateWalk)
            {
                if (triggersTemp==TriggersTemp.TriggerIdle)
                {
                    StateController.CurrentState = _stateIdle;
                    StateController.CurrentState.StateEnterAction();
                }
            }
            else
            {
                if (StateController.CurrentState is StateIdle)
                {
                    if (triggersTemp == TriggersTemp.TriggerWalk)
                    {
                        StateController.CurrentState = _walkState;
                        StateController.CurrentState.StateEnterAction();
                    }
                }
            }
        }*/


        public void TrySetTrigger(TriggersTemp triggerName)
        {
            
            foreach (StateConnection connection in CurrentNode.ConnectionsFromThis)
            {
                if (connection.TriggerName == triggerName)
                {
                    //LastNode = CurrentNode;
                    CurrentNode = connection.StateNodeTo;

                    StateController.CurrentState.StateExitAction(CurrentNode.State);
                    
                    
                    StateController.CurrentState = CurrentNode.State;
                    StateController.CurrentState.StateEnterAction();
                    //CurrentNode.State.StateEnterAction();

                    break;
                }
            }

        }
    }
}
