using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateBody  {

    [MenuItem("Assets/Create/Item/Clothing/Body")]
    public static void CreateMyAsset()
    {
        Body asset = ScriptableObject.CreateInstance<Body>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Clothing/Body/Body.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
