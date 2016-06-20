using UnityEngine;
using UnityEditor;
using System.Collections;
using Assets.ITSystem;

public class CreateItemDataBase {

    [MenuItem("Assets/Create/ItemDataBase")]
    public static void CreateMyAsset()
    {
        ItemDataBase asset = ScriptableObject.CreateInstance<ItemDataBase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemDataBase.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
