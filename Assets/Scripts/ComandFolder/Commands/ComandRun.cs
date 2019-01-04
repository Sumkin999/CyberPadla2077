using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandRun:Command
    {
        public ComandRun()
        {
            //IsNeededProdlenie = true;
        }
        public bool IsProdlena;
        protected override void GetInputData(ComandDataBase comandData)
        {
            ComandDataRun comandDataRun = comandData as ComandDataRun;
            if (comandDataRun != null)
            {
                
            }
        }

        protected override void PrepareCommandoAction()
        {
            StateController.TransformModule.RunSpeedModifier = 2f;

            IsProdlena = true;
            // IsProdlena = true;

        }
        protected override void ExecuteAction()
        {
            Debug.Log("Is Running!");
        }

        protected override bool ContinueCommandoCheck()
        {
            return true;
        }

        protected override void BreakCommandoAction()
        {
            Debug.Log("BreakRun");
            StateController.TransformModule.RunSpeedModifier = 1f;


        }

        protected override void AfterUpdateAction()
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
