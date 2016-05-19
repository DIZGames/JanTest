using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateMaterial  {

    [MenuItem("Assets/Create/Item/Material")]
    public static void CreateMyAsset()
    {
        Materials asset = ScriptableObject.CreateInstance<Materials>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Material/Material.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
