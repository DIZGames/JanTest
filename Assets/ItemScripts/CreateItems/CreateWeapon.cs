using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateWeapon {

    [MenuItem("Assets/Create/Item/Weapon")]
    public static void CreateMyAsset()
    {
        Weapon asset = ScriptableObject.CreateInstance<Weapon>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SingleItems/Weapon/Weapon.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
