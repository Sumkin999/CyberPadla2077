using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateTreeFolder.StateNodes;

namespace Assets.Scripts.StateFolder.StateTreeFolder.StateConnections
{
    public class StateConnection
    {
        public TriggersTemp TriggerName;

        public StateNode StateNodeFrom;
        public StateNode StateNodeTo;
    }
}
