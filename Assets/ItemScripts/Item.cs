using UnityEngine;
using System.Collections;
using UnityEditor;


[System.Serializable]
public class Item: ScriptableObject{
    
    public string itemName;                                     //itemName of the item
    public int itemID;                                          //itemID of the item
    public string itemDesc;                                     //itemDesc of the item
    public Sprite itemIcon;                                     //itemIcon of the item
    public GameObject itemModel;                                //itemModel of the item
    public int itemCount = 1;                                   //itemValue is at start 1
    public int maxItemCount = 1;
    public ItemType itemType;                                   //itemType of the Item




    public Item()
    {

    }

    public Item(string name, int id, string desc, Sprite icon, GameObject model, int maxStack, ItemType type, string sendmessagetext)                 //function to create a instance of the Item
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = icon;
        itemModel = model;
        itemType = type;
    }

    public Item getCopy()
    {
        return (Item)this.MemberwiseClone();
    }

 
}
