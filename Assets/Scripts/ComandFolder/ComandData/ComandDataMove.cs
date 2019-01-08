using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataMove:ComandDataBase
    {
        public Vector3 Vector3;
        public bool IsMoveByPathFind;
        public Transform TransformParent;

        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is CommandMove)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }
        }
    }
}
