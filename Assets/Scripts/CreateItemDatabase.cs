using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateItemDatabase {

    public static ItemList asset;                                                  //The List of all Items

    [MenuItem("Assets/Create/ItemList")]
    public static void createItemDatabase()
    {
        ItemList asset = ScriptableObject.CreateInstance<ItemList>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemDatabase.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
