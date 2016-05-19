using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateTools {

    [MenuItem("Assets/Create/Item/Tool")]
    public static void CreateMyAsset()
    {
        Tool asset = ScriptableObject.CreateInstance<Tool>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Tool/Tool.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
