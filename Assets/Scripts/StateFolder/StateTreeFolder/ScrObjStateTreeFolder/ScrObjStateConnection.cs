using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder
{
    [CreateAssetMenu(fileName = "Connection", menuName = "StateTree/Connections")]
    [System.Serializable]
    public class ScrObjStateConnection:ScriptableObject
    {
        public TriggersTemp TriggerName;

        public ScrObjStateNode FromStateSo;
        public ScrObjStateNode ToStateSo;
    }
}
