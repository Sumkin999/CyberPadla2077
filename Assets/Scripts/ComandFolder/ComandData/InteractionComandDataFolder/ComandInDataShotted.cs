using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.Commands.CommandsInteraction;

namespace Assets.Scripts.ComandFolder.ComandData.InteractionComandDataFolder
{
    public class ComandInDataShotted : ComandDataBase
    {
        protected override void ProcessAction(List<Command> commands)
        {
            foreach (var com in commands)
            {
                if (com is ComandInShotted)
                {
                    com.GetInputDataAndStart(this);

                    return;
                }
            }

        }
    }
}