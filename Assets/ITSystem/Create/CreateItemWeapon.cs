using UnityEngine;
using UnityEditor;
using System.Collections;
using Assets.ITSystem;

public class CreateItemWeapon {

    [MenuItem("Assets/Create/ItemWeapon")]
    public static void CreateMyAsset()
    {
        ItemWeapon asset = ScriptableObject.CreateInstance<ItemWeapon>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemWeapon.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
