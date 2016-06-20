using UnityEngine;
using System.Collections;
using UnityEditor;
using Assets.ITSystem;

[CustomEditor(typeof(SlotListScript))]
public class SlotListEditor : Editor
{


    private int itemIndex;
    private int itemValue;

    public Transform gObject;

    public override void OnInspectorGUI()
    {
        //target ist das Skript, auf das dieses hier verweist
        SlotListScript slScript = (SlotListScript)target;


        gObject = (Transform)EditorGUILayout.ObjectField(gObject, typeof(Transform), true);



        GUILayout.Label("Add an item:");
        // inv.setImportantVariables();                                                                                                            //space to the top gui element
        EditorGUILayout.BeginHorizontal();                                                                                  //starting horizontal GUI elements
        ItemDataBase itemDataBase = (ItemDataBase)Resources.Load("ItemDataBase");

        //ItemDataBaseList inventoryItemList = (ItemDatabase)Resources.Load("ItemDatabase");                            //loading the itemdatabase
        string[] items = new string[itemDataBase.getCount()];

        Item[] items1 = new Item[itemDataBase.getCount()];

        //create a string array in length of the itemcount
        for (int i = 0; i < items.Length; i++)                                                                              //go through the item array
        {
            items[i] = itemDataBase.getItemByIndex(i).Name;                                                            //and paste all names into the array
        }

        itemIndex = EditorGUILayout.Popup("", itemIndex, items, EditorStyles.popup);                                              //create a popout with all itemnames in it and save the itemID of it
        itemValue = EditorGUILayout.IntField("", itemValue, GUILayout.Width(40));
        GUI.color = Color.green;                                                                                            //set the color of all following guielements to green
        if (GUILayout.Button("Add Item"))                                                                                   //creating button with name "AddItem"
        {
            Debug.Log("Add: index:" + itemIndex.ToString() + " value:" + itemValue);


            Item item = itemDataBase.getItemByIndex(itemIndex).getCopy();
            item.Stack = itemValue;
            Debug.Log("ITEM FOUND:" + item.ID.ToString() + " " + item.Stack);

            slScript.addItemToNextFreeSlot(item);

        }
        EditorGUILayout.EndHorizontal();
    }
}
