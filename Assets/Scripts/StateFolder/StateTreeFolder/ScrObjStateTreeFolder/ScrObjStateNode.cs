using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder
{
    [CreateAssetMenu(fileName = "Node", menuName = "StateTree/Nodes")]
    [System.Serializable]
    public class ScrObjStateNode:ScriptableObject
    {
        public string StateName;

        public StateEnum StateEnum;
        public ScrObjStateConnection[] ConnectionsFromThisArray;
    }
}
