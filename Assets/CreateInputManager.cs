using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateInputManager {

    [MenuItem("Assets/Create/InputManager")]
    public static void CreateMyAsset()
    {
        InputManager asset = ScriptableObject.CreateInstance<InputManager>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/InputManager.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
