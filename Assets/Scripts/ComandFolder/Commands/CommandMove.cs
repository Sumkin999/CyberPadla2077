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
        public CommandMove()
        {
            //IsNeededProdlenie = true;
        }

        public bool IsProdlena;

        private Vector3 _targetVector3;
        private bool _isPfGet;
        private Transform _parentTransform;
        private float _distanceToTargetTransform;
        protected override bool StartConditionCheck()
        {
            
            return true;
        }
        protected override void GetInputData(ComandDataBase comandData)
        {
            ComandDataMove comandDataMove=comandData as ComandDataMove;
            if (comandDataMove!=null)
            {
                _targetVector3 = comandDataMove.Vector3;

                _isPfGet = comandDataMove.IsMoveByPathFind;

                if (comandDataMove.TransformParent!=null)
                {
                    _parentTransform = comandDataMove.TransformParent;
                }
                else
                {
                    _parentTransform = null;
                }
                
            }
            
            
        }
        //TODO
        /*
         
             
             MovePathControl-получать параметр Вектор3, а 
             НЕ ЗАДАВАТЬ как
             StateController.TransformModule.MoveTargetVector3 = _targetVector3-StateController.TransformModule.MainTransform.position;

            в MovePathControl всешда задаетя local направление
             
             
        */


        protected override void PrepareCommandoAction()
        {

            StateController.TransformModule.PathFindIsOn = _isPfGet;
            
            if (!_isPfGet)
            {
                StateController.TransformModule.MoveTargetVector3 = _targetVector3;
            }
            else
            {
                if (_parentTransform == null)
                {
                    StateController.TransformModule.PathFindTransform.parent = null;
                    StateController.TransformModule.PathFindTransform.position = _targetVector3;
                }
                else
                {
                    StateController.TransformModule.PathFindTransform.parent = _parentTransform;
                    StateController.TransformModule.PathFindTransform.position = _parentTransform.position;
                }
            }

            StateController.AddTrigger(TriggersTemp.TriggerWalk);
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
            if (StateController.TransformModule.PathFindIsOn)
            {
                _distanceToTargetTransform = Vector3.Distance(StateController.TransformModule.MainTransform.position,
                    StateController.TransformModule.PathFindTransform.position);
                StateController.TransformModule.PathFindMovePrepare();

                //Debug.Log("Dist "+ _distanceToTargetTransform);
            }
            else
            {
                StateController.TransformModule.FreeMovePrepare();
            }
            
            StateController.TransformModule.MoveAnimationControl();
            
            
            
        }

        protected override void BreakCommandoAction()
        {
            StateController.AddTrigger(TriggersTemp.TriggerIdle);


        }
        protected override void AfterUpdateAction()
        {
            if (StateController.TransformModule.PathFindIsOn && _distanceToTargetTransform>1.2f)
            {
                IsProdlena = true;
            }
            else
            {
                if (!IsProdlena)
                {
                    UnIniciate();
                }
                else
                {
                    IsProdlena = false;
                }
            }
            

            
        }

    }
}
