using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.Commands;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataAim:ComandDataBase
    {
        public bool IsPrimaryPressed;
        public bool IsSecondaryPressed;

        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is ComandAim)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }
        }
    }
}
