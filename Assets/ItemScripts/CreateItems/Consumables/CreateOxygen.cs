using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateOxygen {

    [MenuItem("Assets/Create/Item/Consumable/Oxygen")]
    public static void CreateMyAsset()
    {
        Oxygen asset = ScriptableObject.CreateInstance<Oxygen>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Consumable/Oxygen/Oxygen.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
