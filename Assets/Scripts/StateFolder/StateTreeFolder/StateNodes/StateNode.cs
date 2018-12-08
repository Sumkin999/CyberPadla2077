using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.StateFolder.StateHumFolder;
using Assets.Scripts.StateFolder.StateTreeFolder.StateConnections;

namespace Assets.Scripts.StateFolder.StateTreeFolder.StateNodes
{
    public class StateNode
    {
        public StateBase State;

        public StateConnection[] ConnectionsFromThis;
    }
}
