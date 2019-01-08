using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.Commands;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataRotate:ComandDataBase
    {
        public Vector3 LookAtVector3;

        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is ComandRotate)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }
        }
    }
}
