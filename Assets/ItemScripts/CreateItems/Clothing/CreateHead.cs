using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateHead {

    [MenuItem("Assets/Create/Item/Clothing/Head")]
    public static void CreateMyAsset()
    {
        Head asset = ScriptableObject.CreateInstance<Head>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Clothing/Head/Head.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
