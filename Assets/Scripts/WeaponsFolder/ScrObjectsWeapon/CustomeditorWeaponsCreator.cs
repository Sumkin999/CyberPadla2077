using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.WeaponsFolder.ScrObjectsWeapon
{
    [CustomEditor(typeof(ScrObjEditorWeaponCreator))]
    public class CustomeditorWeaponsCreator:Editor
    {
#if UNITY_EDITOR
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.BeginHorizontal();
            EditorUtility.SetDirty(target);
            if (GUILayout.Button("Build Weapon"))
            {
                EditorApplication.delayCall += CreateTree;
                EditorUtility.SetDirty(target);
            }
            EditorGUILayout.EndHorizontal();
        }
        protected void CreateTree()
        {
            ScrObjEditorWeaponCreator myScript = (ScrObjEditorWeaponCreator)target;
            EditorUtility.SetDirty(myScript);
            myScript.Create();
        }
#endif
    }
}
