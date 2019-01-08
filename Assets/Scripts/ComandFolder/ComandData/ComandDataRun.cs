using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.Commands;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataRun:ComandDataBase
    {
        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is ComandRun)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }
        }
    }
}
