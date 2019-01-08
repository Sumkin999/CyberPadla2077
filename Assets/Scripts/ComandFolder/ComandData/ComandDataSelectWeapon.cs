using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.Commands;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataSelectWeapon:ComandDataBase
    {
        public bool IsForward;

        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is ComandSelectWeapon)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }
        }
    }
}
