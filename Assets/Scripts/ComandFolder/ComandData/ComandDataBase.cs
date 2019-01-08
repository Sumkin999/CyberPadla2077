using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public abstract class ComandDataBase
    {
        public bool IsProcessed { get; private set; }

        public void Process(List<Command> commands)
        {
            ProcessAction(commands);

            IsProcessed = true;
        }

        protected abstract void ProcessAction(List<Command> commands );



    }
}
