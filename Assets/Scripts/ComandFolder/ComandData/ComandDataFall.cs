using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.Commands;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataFall:ComandDataBase
    {
        public Rigidbody HumanRigidbody;

        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is ComandFall)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }
        }
    }
}
