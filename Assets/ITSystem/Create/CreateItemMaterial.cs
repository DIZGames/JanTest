using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.ITSystem.Create {
    public class CreateItemMaterial {

        [MenuItem("Assets/Create/ItemMaterial")]
        public static void CreateMyAsset() {
            ItemMaterial asset = ScriptableObject.CreateInstance<ItemMaterial>();

            AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemMaterial.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
