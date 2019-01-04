using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.Commands
{
    public class ComandRotate:Command
    {
        public ComandRotate()
        {
            //IsNeededProdlenie = true;
        }
        public bool IsProdlena;
        private Vector3 _targetVector3;


        protected override void GetInputData(ComandDataBase comandData)
        {
            ComandDataRotate comandDataRotate = comandData as ComandDataRotate;
            if (comandDataRotate != null)
            {
                _targetVector3 = comandDataRotate.LookAtVector3;
                //StartCommando();
            }
        }


        protected override void PrepareCommandoAction()
        {
            StateController.TransformModule.LookAtVector3 = _targetVector3;
            

            IsProdlena = true;

        }
        protected override void ExecuteAction()
        {
            StateController.TransformModule.Rotate();
        }

        protected override bool ContinueCommandoCheck()
        {
            return true;
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
