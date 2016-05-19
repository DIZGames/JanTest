using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateFood : MonoBehaviour {

    [MenuItem("Assets/Create/Item/Consumable/Food")]
    public static void CreateMyAsset()
    {
        Food asset = ScriptableObject.CreateInstance<Food>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Consumable/Food/Food.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
