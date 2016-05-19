using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAmmo {

    [MenuItem("Assets/Create/Item/Ammo")]
    public static void CreateMyAsset()
    {
        Ammo asset = ScriptableObject.CreateInstance<Ammo>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Ammo/Ammo.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
