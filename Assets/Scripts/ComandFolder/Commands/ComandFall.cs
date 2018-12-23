using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandFall:Command
    {
        private Rigidbody _humanRigidbody;
        private float _groundedTimer;

        protected override void GetInputData(ComandDataBase comandData)
        {
            ComandDataFall comandDatafall = comandData as ComandDataFall;
            if (comandDatafall != null)
            {
                _humanRigidbody = comandDatafall.HumanRigidbody;
                _groundedTimer = 2f;
            }
        }


        protected override void PrepareCommandoAction()
        {
            StateController.Triggers.Add(TriggersTemp.TriggerFall);

        }

        protected override void ExecuteAction()
        {
            Debug.Log(_groundedTimer+"  "+_humanRigidbody.velocity.y);
            if (Mathf.Abs(_humanRigidbody.velocity.y)<.1f)
            {
                _groundedTimer -= Time.deltaTime;
            }
            else
            {
                if (!StateController.PhysicsModule.HumanRagdoll.IsFullRagdoll)
                {
                    Debug.Log("Fall Again!");
                    StateController.PhysicsModule.HumanRagdoll.RagdollOn();
                }
                _groundedTimer = 2f;
            }
        }

        protected override bool ContinueCommandoCheck()
        {
            if (_groundedTimer > 0)
            {
                return true;
            }
            return false;
            
        }

        protected override void BreakCommandoAction()
        {
            Debug.Log("Time To GetUp!");

        }
    }
}
