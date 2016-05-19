using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateMod  {

    [MenuItem("Assets/Create/Item/Clothing/Mod")]
    public static void CreateMyAsset()
    {
        Mod asset = ScriptableObject.CreateInstance<Mod>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Clothing/Mod/Mod.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
