using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.StateFolder.StateHumFolder;
using Assets.Scripts.StateFolder.StateTreeFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public enum TriggersTemp
    {
        TriggerIdle,
        TriggerWalk
    }
    public class StateController
    {
        public StateController(IFacade iFacade,TransformModule transformModule, AnimatorModule animatorModule, PhysicsModule physicsModule)
        {
            TransformModule = transformModule;
            AnimatorModule = animatorModule;
            PhysicsModule = physicsModule;
            Ifacade = iFacade;

            StateTree=new StateTree(this);
            CurrentState = StateTree._stateIdle;
        }
        public TransformModule TransformModule;
        public AnimatorModule AnimatorModule;
        public PhysicsModule PhysicsModule;
        public IFacade Ifacade;

        public StateBase CurrentState;
        public StateTree StateTree;
        
        public List<TriggersTemp>Triggers=new List<TriggersTemp>();


        public void StateControllerUpdateAction()
        {
            CurrentState.StateUpdateAction();

            if (Triggers.Count>0)
            {
                //StateTree.NewStateTrigger(Triggers[0]);
                StateTree.TrySetTrigger(Triggers[0]);

                Triggers.RemoveAt(0);
            }
        }
    }
}
