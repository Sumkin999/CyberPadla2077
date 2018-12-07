using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class CommandMove:Command, INeedDataToContinue
    {
        private bool _isProdlena;
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
        }
        public override bool StartConditionCheck()
        {
            Debug.Log("AAA");
            return true;
        }
        public override void GetInputData(ComandDataBase comandData)
        {
            StartCommando();
            
        }
        public override void PrepareCommandoAction()
        {
            StateController.TransformModule.Move();
            if (StateController.CurrentState is StateIdle)
            {
                //Debug.Log("WalkTrigger Added!");
                StateController.Triggers.Add(TriggersTemp.TriggerWalk);
            }
            
            Prodlit();
        }
        public override bool ContinueCommandoCheck()
        {
            return true;
        }

        public override void ExecuteAction()
        {
            
                
            
            
            //Debug.Log("Move DATA!");
            //StateController.TransformModule.MainTransform.transform.Translate(Vector3.forward*Time.deltaTime);
        }

        public override void BreakCommandoAction()
        {
            if (StateController.CurrentState is StateWalk)
            {
                //Debug.Log("IdleTrigger Added!"+StateController.CurrentState);
                StateController.Triggers.Add(TriggersTemp.TriggerIdle);
            }
            
        }

        
    }
}
