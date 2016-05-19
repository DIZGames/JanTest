using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateBlocks {

    [MenuItem("Assets/Create/Item/Block")]
    public static void CreateMyAsset()
    {
        Block asset = ScriptableObject.CreateInstance<Block>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Block/Block.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
