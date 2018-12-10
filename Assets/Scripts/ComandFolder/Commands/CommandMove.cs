using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class CommandMove:Command//, INeedDataToContinue
    {
        public CommandMove(bool isNeedProdlenie)
        {
            IsNeededProdlenie = isNeedProdlenie;
        }
        /*private bool _isProdlena;
        public bool IsProdlena
        {
            get
            {
                return _isProdlena;
            }

            set
            {
                Debug.Log("Cant Prodlit!");
            }
        }

        public void Prodlit()
        {
            _isProdlena = true;
        }
        public void UnProdlit()
        {
            _isProdlena = false;
        }*/


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
            }
            
            
        }
        protected override void PrepareCommandoAction()
        {
            StateController.TransformModule.TargetVector3 = _targetVector3-StateController.TransformModule.MainTransform.position;
            StateController.TransformModule.TargetVector3.Normalize();


            StateController.TransformModule.Move();
            if (!StateController.CurrentState.StateFlags.IsMoving)
            {
                //Debug.Log("WalkTrigger Added!");
                StateController.Triggers.Add(TriggersTemp.TriggerWalk);
            }

            IsProdlena = true;
            //Prodlit();
        }
        protected override bool ContinueCommandoCheck()
        {
            return true;
        }

        protected override void ExecuteAction()
        {
            
                
            
            
            //Debug.Log("Move DATA!");
            //StateController.TransformModule.MainTransform.transform.Translate(Vector3.forward*Time.deltaTime);
        }

        protected override void BreakCommandoAction()
        {
            if (StateController.CurrentState.StateFlags.IsMoving)
            {
                //Debug.Log("IdleTrigger Added!"+StateController.CurrentState);
                StateController.Triggers.Add(TriggersTemp.TriggerIdle);
            }
            
        }

        
    }
}
