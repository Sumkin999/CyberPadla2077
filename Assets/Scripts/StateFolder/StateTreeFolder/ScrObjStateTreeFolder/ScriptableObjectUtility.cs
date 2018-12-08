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
    public static class ScriptableObjectUtility
    {
        /// <summary>
        //	This makes it easy to create, name and place unique new ScriptableObject asset files.
        /// </summary>
        /// 
        /// 
        public static T CreateAsset<T>(string path, string name) where T : ScriptableObject
        {
#if UNITY_EDITOR
            T asset = ScriptableObject.CreateInstance<T>();

            string name2 = AssetDatabase.GenerateUniqueAssetPath(path + name + ".asset");
            AssetDatabase.CreateAsset(asset, name2);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;


#endif
        }
    }
}
