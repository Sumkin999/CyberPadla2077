using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Animations;
using UnityEditor;
#endif

namespace Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder
{
    [CreateAssetMenu(fileName = "Creator", menuName = "StateTree/TreeCreator", order = 1)]
    public class ScrObjectEditorStateTreeCreator:ScriptableObject
    {
#if UNITY_EDITOR



        [System.Serializable]
        public struct StringToStateStruct
        {
            public string StateName;
            public StateEnum StateEnum;
        }
        [System.Serializable]
        public struct StringToTriggerNameStruct
        {
            public string TriggerName;
            public TriggersTemp TriggerEnum;
        }

        public StateEnum GetStateEnumFromStringKey(string keyName)
        {
            foreach (var pair in StateDictionary)
            {
                if (pair.StateName == keyName)
                {
                    return pair.StateEnum;
                }
            }

            Debug.LogAssertion("Not Found!!!");

            return StateEnum.IdleState;

        }


        public List<StringToStateStruct> StateDictionary = new List<StringToStateStruct>();
        public List<StringToTriggerNameStruct> TriggerDictionary = new List<StringToTriggerNameStruct>();




        public string TreeFolderName;


        public AnimatorController Animator;
        private AnimatorStateMachine _asm;
        public ScrObjStateTree StateTreeSo;


        public void Create()
        {
            string strFolder = "Assets/StateTrees/Trees";

            AssetDatabase.CreateFolder(strFolder, TreeFolderName);

            strFolder += "/" + TreeFolderName;
            string mainFolderString = strFolder + "/";

            StateTreeSo = ScriptableObjectUtility.CreateAsset<ScrObjStateTree>(mainFolderString, "TreeOfLife");

            string thisNodesPath = "Nodes";
            string thisConnectionsString = "Connections";
            AssetDatabase.CreateFolder(strFolder, thisNodesPath);
            AssetDatabase.CreateFolder(strFolder, thisConnectionsString);
            thisNodesPath = mainFolderString + "Nodes/";
            thisConnectionsString = mainFolderString + "Connections/";



            _asm = Animator.layers[0].stateMachine;

            List<ScrObjStateNode> nodelist = new List<ScrObjStateNode>();
            List<ScrObjStateConnection> conlist = new List<ScrObjStateConnection>();
            Dictionary<AnimatorState, ScrObjStateNode> dic = new Dictionary<AnimatorState, ScrObjStateNode>();
            Dictionary<AnimatorStateTransition, ScrObjStateConnection> dicCon = new Dictionary<AnimatorStateTransition, ScrObjStateConnection>();

            foreach (var node in _asm.states)
            {
                string stateName = node.state.name;

                ScrObjStateNode sNode = ScriptableObjectUtility.CreateAsset<ScrObjStateNode>(thisNodesPath, stateName);
                EditorUtility.SetDirty(sNode);


                sNode.StateEnum = GetStateEnumFromStringKey(stateName);
                sNode.StateName = sNode.StateEnum.ToString();

                //sNode.StateEnum.StateFlags=new StateTransformFlags();


                nodelist.Add(sNode);
                dic.Add(node.state, sNode);
            }
            foreach (var nodState in dic.Keys)
            {

                foreach (var con in nodState.transitions)
                {
                    AnimatorTransitionBase atr = con;
                    string t = atr.destinationState.name;
                    ScrObjStateConnection sCon = ScriptableObjectUtility.CreateAsset<ScrObjStateConnection>(thisConnectionsString, nodState.name + "-" + t);

                    EditorUtility.SetDirty(sCon);

                    sCon.FromStateSo = dic[nodState];


                    sCon.ToStateSo = dic[atr.destinationState];



                    //TODO триггер перехода

                    foreach (var condition in atr.conditions)
                    {
                        sCon.TriggerName = GetTriggerNameFromDictionary(condition.parameter);
                    }

                    dicCon.Add(con, sCon);
                    conlist.Add(sCon);
                }

            }

            foreach (var nodState in dic.Keys)
            {
                List<ScrObjStateConnection> slist = new List<ScrObjStateConnection>();
                foreach (var con in dicCon.Keys)
                {
                    if (nodState.transitions.Contains(con))
                    {
                        slist.Add(dicCon[con]);
                    }
                }
                dic[nodState].ConnectionsFromThisArray = slist.ToArray();
            }


            StateTreeSo.NodesSo = nodelist.ToArray();
            StateTreeSo.ConnectionsSo = conlist.ToArray();

            EditorUtility.SetDirty(StateTreeSo);
            foreach (var stateConnectionSo in StateTreeSo.ConnectionsSo)
            {
                EditorUtility.SetDirty(stateConnectionSo);
            }
            foreach (var stateNodeSo in StateTreeSo.NodesSo)
            {
                EditorUtility.SetDirty(stateNodeSo);
            }




        }


        TriggersTemp GetTriggerNameFromDictionary(string str)
        {
            foreach (var item in TriggerDictionary)
            {
                if (item.TriggerName == str)
                {
                    return item.TriggerEnum;
                }
            }

            Debug.LogAssertion("Error!");
            return TriggersTemp.TriggerIdle;
        }



#endif
    }
}

