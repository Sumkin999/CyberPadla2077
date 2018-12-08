using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder
{
    [CustomEditor(typeof(ScrObjectEditorStateTreeCreator))]
    public class CustomEditorStateTreeCreator:Editor
    {
#if UNITY_EDITOR

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.BeginHorizontal();
            EditorUtility.SetDirty(target);
            if (GUILayout.Button("Build Object"))
            {
                EditorApplication.delayCall += CreateTree;
                EditorUtility.SetDirty(target);
            }
            EditorGUILayout.EndHorizontal();
        }
        protected void CreateTree()
        {
            ScrObjectEditorStateTreeCreator myScript = (ScrObjectEditorStateTreeCreator)target;
            EditorUtility.SetDirty(myScript);
            myScript.Create();
        }



#endif
    }
}
