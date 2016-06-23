using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.ITSystem.Create {
    public class CreateItemConsumable {
        [MenuItem("Assets/Create/ItemConsumable")]
        public static void CreateMyAsset() {
            ItemConsumable asset = ScriptableObject.CreateInstance<ItemConsumable>();

            AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemConsumable.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
