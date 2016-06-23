using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.ITSystem.Create {
    public class CreateItemTool {

        [MenuItem("Assets/Create/ItemTool")]
        public static void CreateMyAsset() {
            ItemTool asset = ScriptableObject.CreateInstance<ItemTool>();

            AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemTool.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
