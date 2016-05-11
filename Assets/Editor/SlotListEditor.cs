using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SlotListScript))]
public class SlotListEditor : Editor {

    private int itemID;
    private int itemValue = 1;
    private int imageTypeIndex;

    public override void OnInspectorGUI()
    {
        //target ist das Skript, auf das dieses hier verweist
        SlotListScript slScript = (SlotListScript)target;



        GUILayout.Label("Add an item:");
        // inv.setImportantVariables();                                                                                                            //space to the top gui element
        EditorGUILayout.BeginHorizontal();                                                                                  //starting horizontal GUI elements
        ItemList itemList = (ItemList)Resources.Load("ItemDatabase");
        //ItemDataBaseList inventoryItemList = (ItemDatabase)Resources.Load("ItemDatabase");                            //loading the itemdatabase
        string[] items = new string[itemList.itemList.Count];                                                      //create a string array in length of the itemcount
        for (int i = 0; i < items.Length; i++)                                                                              //go through the item array
        {
            items[i] = itemList.itemList[i].itemName;                                                              //and paste all names into the array
        }
        itemID = EditorGUILayout.Popup("", itemID, items, EditorStyles.popup);                                              //create a popout with all itemnames in it and save the itemID of it
        itemValue = EditorGUILayout.IntField("", itemValue, GUILayout.Width(40));
        GUI.color = Color.green;                                                                                            //set the color of all following guielements to green
        if (GUILayout.Button("Add Item"))                                                                                   //creating button with name "AddItem"
        {
            slScript.addById(itemID, itemValue);
            Debug.Log("Add:" + itemID.ToString() + " " + itemValue);
            //inv.addItemToInventory(itemID, itemValue);                                                                      //and set the settings for possible stackedItems
            //inv.stackableSettings();
        }

        //inv.OnUpdateItemList();

        EditorGUILayout.EndHorizontal();
    }
}
