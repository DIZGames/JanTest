using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateItem{



    [MenuItem("Assets/Create/Item")]
    public static void CreateMyAsset()
    {
        Item asset = ScriptableObject.CreateInstance<Item>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItem/Item.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }


}
