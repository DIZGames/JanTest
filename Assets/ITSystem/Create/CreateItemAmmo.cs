using UnityEngine;
using UnityEditor;
using System.Collections;
using Assets.ITSystem;

public class CreateItemAmmo {

    [MenuItem("Assets/Create/ItemAmmo")]
    public static void CreateMyAsset()
    {
        ItemAmmo asset = ScriptableObject.CreateInstance<ItemAmmo>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemAmmo.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
