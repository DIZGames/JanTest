using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateDrink  {

    [MenuItem("Assets/Create/Item/Consumable/Drink")]
    public static void CreateMyAsset()
    {
        Drink asset = ScriptableObject.CreateInstance<Drink>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Consumable/Drink/Drink.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
