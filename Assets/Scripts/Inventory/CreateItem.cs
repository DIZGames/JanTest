using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateItem{



    [MenuItem("Assets/Create/Item")]
    public static void CreateMyAsset()
    {
        Items asset = ScriptableObject.CreateInstance<Items>();

        AssetDatabase.CreateAsset(asset, "Assets/ItemDatabase/Item.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }


}
