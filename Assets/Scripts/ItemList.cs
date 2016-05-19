using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemList: ScriptableObject
{
    [SerializeField]
    private List<Item> itemList = new List<Item>();              //List of it


    public Item getItemByListIndex(int index)
    {
        return itemList[index].getCopy();
    }

    public Item getItemByID(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemID == id)
                return itemList[i].getCopy();
        }
        return null;
    }

    public Item getItemByName(string name)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemName.ToLower().Equals(name.ToLower()))
                return itemList[i].getCopy();
        }
        return null;
    }

    public int getCount() {
        return itemList.Count;
    }

}
