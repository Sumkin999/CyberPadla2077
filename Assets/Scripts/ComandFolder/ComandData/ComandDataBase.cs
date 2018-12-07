using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public class ComandDataBase
    {
        public bool IsProcessed { get; private set; }

        public void Process()
        {
            
            IsProcessed = true;
        }

        
    }
}
