using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.StateFolder.StateControllerFolder;
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
            StateComandManager=new StateComandManager(this);
            //CurrentState = StateTree.SetIdleStateAsCurrent();
        }
        public TransformModule TransformModule;
        public AnimatorModule AnimatorModule;
        public PhysicsModule PhysicsModule;
        public WeaponModule WeaponModule;
        public IFacade Ifacade;

        public StateComandManager StateComandManager;

        public StateBase CurrentState;
        public StateTree StateTree;
        
        protected List<TriggersTemp>Triggers=new List<TriggersTemp>();

        public void AddTrigger(TriggersTemp newTrigger)
        {
            switch (newTrigger) 
            {
                case TriggersTemp.TriggerWalk:
                {
                    if (!CurrentState.StateFlags.IsMoving)
                    {
                        Triggers.Add(newTrigger);
                    }
                    break;
                }
                case TriggersTemp.TriggerIdle:
                {
                    if (CurrentState.StateFlags.IsMoving)
                    {
                        Triggers.Add(newTrigger);
                    }
                    break;
                }
                case TriggersTemp.TriggerAim:
                {
                    if (!CurrentState.StateFlags.IsAiming)
                    {
                        Triggers.Add(newTrigger);
                    }
                    break;
                }
                case TriggersTemp.TriggerUnaim:
                {
                    if (CurrentState.StateFlags.IsAiming)
                    {
                        Triggers.Add(newTrigger);
                    }
                    break;
                }
                case TriggersTemp.TriggerFall:
                {
                    
                        Triggers.Add(newTrigger);
                    
                    break;
                }
                case TriggersTemp.TriggerGetUp:
                {
                    
                        Triggers.Add(newTrigger);
                    
                    break;
                }
            }
            
        }

        public void StateControllerUpdateAction()
        {
            if (CurrentState == null)
            {
                return;
            }
            CurrentState.StateUpdateAction();

            if (Triggers.Count>0)
            {
                
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
