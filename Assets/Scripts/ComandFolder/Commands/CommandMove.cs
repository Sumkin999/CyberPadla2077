using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class CommandMove:Command
    {
        public CommandMove(bool isNeedProdlenie)
        {
            IsNeededProdlenie = isNeedProdlenie;
        }



        private Vector3 _targetVector3;
        protected override bool StartConditionCheck()
        {
            
            return true;
        }
        public override void GetInputData(ComandDataBase comandData)
        {
            ComandDataMove comandDataMove=comandData as ComandDataMove;
            if (comandDataMove!=null)
            {
                _targetVector3 = comandDataMove.Vector3;
                StartCommando();
            }
            
            
        }
        protected override void PrepareCommandoAction()
        {
            
            //TODO ПЕРЕДЕЛАТЬ
            StateController.TransformModule.MoveTargetVector3 = _targetVector3-StateController.TransformModule.MainTransform.position;
            StateController.TransformModule.MoveTargetVector3.Normalize();

            if (!StateController.CurrentState.StateFlags.IsMoving)
            {
                StateController.Triggers.Add(TriggersTemp.TriggerWalk);
            }

            IsProdlena = true;

        }

        protected override void FixedExecuteAction()
        {
            StateController.TransformModule.Move();
        }
        protected override bool ContinueCommandoCheck()
        {
            return true;
        }

        protected override void ExecuteAction()
        {

            StateController.TransformModule.MovePathControl();
            StateController.TransformModule.MoveAnimationControl();
            
            
            
        }

        protected override void BreakCommandoAction()
        {
            if (StateController.CurrentState.StateFlags.IsMoving)
            {
                StateController.Triggers.Add(TriggersTemp.TriggerIdle);
            }
            
        }

        
    }
}
