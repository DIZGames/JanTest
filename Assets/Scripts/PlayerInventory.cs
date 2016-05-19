using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour, IHasChanged {

    [SerializeField]
    private GameObject PrefabItemSlot;
    [SerializeField]
    private ItemList ItemDataBase;
    [SerializeField]
    private GameObject BackPack;
    [SerializeField]
    private GameObject HotBar;

    List<Item> PlayerInventoryList = new List<Item>();

    public void DropItem(Item item)
    {
        if (PlayerInventoryList.Contains(item)) {

        }


        Debug.Log("Drop Item!");
        Debug.Log(item.itemName);
        Debug.Log("Drop Item!");
    }

    public void HasChanged()
    {
        Debug.Log("Fired!");
    }

    public void TakeItem()
    {
        Debug.Log("Take Item!");
        Debug.Log("Take Item!");
    }

    // Use this for initialization
    void Start () {
        HasChanged();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
        void DropItem(Item item);
        void TakeItem();
    }
}