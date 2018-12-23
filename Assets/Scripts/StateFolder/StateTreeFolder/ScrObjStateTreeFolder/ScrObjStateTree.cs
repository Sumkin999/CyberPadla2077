using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.StateFolder.StateHumFolder;
using Assets.Scripts.StateFolder.StateTreeFolder.StateConnections;
using Assets.Scripts.StateFolder.StateTreeFolder.StateNodes;
using UnityEngine;

namespace Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder
{
    public enum StateEnum
    {
        IdleState,
        WalkState,
        AimStandingState,
        AimWalkingState,
        FallingState
    }

    [CreateAssetMenu(fileName = "Tree", menuName = "StateTree/Trees", order = 1)]
    [System.Serializable]
    public class ScrObjStateTree:ScriptableObject
    {
        public ScrObjStateNode[] NodesSo;
        public ScrObjStateConnection[] ConnectionsSo;

        public StateBase GetStateFromEnum(StateEnum stateEnum,StateController stateController)
        {
            switch (stateEnum)
            {
                case StateEnum.IdleState:
                    return new StateIdle(stateController);

                case StateEnum.WalkState:
                    return new StateWalk(stateController);

                case StateEnum.AimStandingState:
                    return new StateAimStanding(stateController);

                case StateEnum.AimWalkingState:
                    return new StateAimWalking(stateController);

                case StateEnum.FallingState:
                    return new StateFalling(stateController);

                
            }

            Debug.LogAssertion("Error!");
            return null;
        }


        public void InicateTree( StateController stateController)
        {
            stateController.StateTree = new StateTree(stateController);

            List<StateNode> nodelist = new List<StateNode>();
            foreach (var node in NodesSo)
            {
                StateNode n = new StateNode();
                n.State = GetStateFromEnum(node.StateEnum,stateController);

                nodelist.Add(n);
            }
            stateController.StateTree.Nodes = nodelist.ToArray();


            List<StateConnection> conlist = new List<StateConnection>();
            foreach (ScrObjStateConnection conSo in ConnectionsSo)
            {
                StateConnection stateNodeConnection = new StateConnection();
                stateNodeConnection.TriggerName = conSo.TriggerName;
                int f = Array.IndexOf(NodesSo, conSo.FromStateSo);
                int t = Array.IndexOf(NodesSo, conSo.ToStateSo);
                stateNodeConnection.StateNodeFrom = stateController.StateTree.Nodes[f];
                stateNodeConnection.StateNodeTo = stateController.StateTree.Nodes[t];


                conlist.Add(stateNodeConnection);
            }
            stateController.StateTree.Connections = conlist.ToArray();


            foreach (var nod in stateController.StateTree.Nodes)
            {
                List<StateConnection> cs = new List<StateConnection>();
                foreach (var con in stateController.StateTree.Connections)
                {
                    if (con.StateNodeFrom == nod)
                    {
                        cs.Add(con);
                    }
                }
                nod.ConnectionsFromThis = cs.ToArray();
            }

            stateController.StateTree.CurrentNode = stateController.StateTree.Nodes[0];

            stateController.CurrentState= stateController.StateTree.SetIdleStateAsCurrent();
            //stateController.StateTree.LastNode = humanStateModule.StateTree.Nodes[0];

        }


    }
}
