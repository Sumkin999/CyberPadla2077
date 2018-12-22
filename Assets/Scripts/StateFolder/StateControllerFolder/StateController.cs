﻿using System;
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
        TriggerWalk,
        TriggerAim,
        TriggerUnaim,
        TriggerFall,
        TriggerFalled,
        TriggerGetUp
    }
    public class StateController
    {
        public StateController(IFacade iFacade,TransformModule transformModule, AnimatorModule animatorModule, PhysicsModule physicsModule,WeaponModule weaponModule)
        {
            TransformModule = transformModule;
            AnimatorModule = animatorModule;
            PhysicsModule = physicsModule;
            WeaponModule = weaponModule;
            Ifacade = iFacade;

            StateTree=new StateTree(this);
            //CurrentState = StateTree.SetIdleStateAsCurrent();
        }
        public TransformModule TransformModule;
        public AnimatorModule AnimatorModule;
        public PhysicsModule PhysicsModule;
        public WeaponModule WeaponModule;
        public IFacade Ifacade;

        public StateBase CurrentState;
        public StateTree StateTree;
        
        public List<TriggersTemp>Triggers=new List<TriggersTemp>();


        public void StateControllerUpdateAction()
        {
            if (CurrentState == null)
            {
                return;
            }
            CurrentState.StateUpdateAction();

            if (Triggers.Count>0)
            {
                //StateTree.NewStateTrigger(Triggers[0]);
                if (Triggers[0]==TriggersTemp.TriggerFall)
                {
                    Debug.Log("Fall Trigger");
                }
                StateTree.TrySetTrigger(Triggers[0]);

                Triggers.RemoveAt(0);
            }


            WeaponModule.ModuleUpdateAction();
        }

        public void StateControllerFixedUpdateAction()
        {
            if (CurrentState==null)
            {
                return;
            }
            CurrentState.StateFixedUpdateAction();
        }

        
    }
}
