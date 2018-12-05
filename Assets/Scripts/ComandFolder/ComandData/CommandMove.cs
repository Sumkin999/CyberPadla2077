using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class CommandMove:Command
    {

        public override void GetInputData(ComandDataBase comandData)
        {
            StartCommando();
        }
        public override bool ContinueCommandoCheck()
        {
            return true;
        }

        public override void ExecuteAction()
        {
            Debug.Log("Move DATA!");
            StateController.TransformModule.MainTransform.transform.Translate(Vector3.forward*Time.deltaTime);
        }
    }
}
