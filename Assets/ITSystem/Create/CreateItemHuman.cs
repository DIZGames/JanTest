using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.ITSystem.Create {
    public class CreateItemHuman {

        [MenuItem("Assets/Create/ItemHuman")]
        public static void CreateMyAsset() {
            ItemHuman asset = ScriptableObject.CreateInstance<ItemHuman>();

            AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemHuman.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
