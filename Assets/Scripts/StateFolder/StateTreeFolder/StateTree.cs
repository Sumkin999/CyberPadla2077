using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;

namespace Assets.Scripts.StateFolder.StateTreeFolder
{
    public class StateTree
    {
        public StateTree(StateController stateController)
        {
            StateController = stateController;

            _walkState=new StateWalk(StateController);
            _stateIdle=new StateIdle(StateController);
        }
        public StateController StateController;

        public StateWalk _walkState;
        public StateIdle _stateIdle;

        public void NewStateTrigger(TriggersTemp triggersTemp)
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
        }
    }
}
