using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Assets.ITSystem;
using Assets.Scripts;
using UnityEngine.Events;
using Assets;
using Assets.EventSystem;

public class PlayerInventory : MonoBehaviour{

    [SerializeField]
    private ItemDataBase itemDataBase;
    [SerializeField]
    private Transform backPack;
    [SerializeField]
    private Transform hotBar;
    [SerializeField]
    private Transform characterScreen;
    [SerializeField]
    private Transform craftSystem;
    [SerializeField]
    private Transform equipmentPoint; 
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject SlotItem;
    [SerializeField]
    private Transform AmmoScreen;

    List<Item> PlayerInventoryList = new List<Item>();

    

    public void DropItem(Item item)
    {

        Debug.Log("PlayerInventory: DroppedItem");
        
    }
    public void HasChanged()
    {
        Debug.Log("PlayerInventory: HasChanged");
        
    }
    UnityAction<customEventData> asd2;
    UnityAction<Item> asd3;

    void Start()
    {
        asd2 = test3;
        asd2 += test4;
        asd3 = test666;


        EventManager.Instance.AddListener("test",asd2);
        EventManager.Instance.AddListener("AddToInventory",asd3);


        //EventManager.Instance.RegisterToWordEvent(UnityAction<string>);
    }

    public void test666(Item _item) {
        for (int i = 0; i < backPack.GetChild(0).childCount; i++) {
            if (backPack.GetChild(0).GetChild(i).childCount == 0) {

                GameObject gObject = Instantiate(SlotItem);
                gObject.transform.SetParent(backPack.GetChild(0).GetChild(i));
                gObject.transform.position = backPack.GetChild(0).GetChild(i).position;
                gObject.GetComponent<ItemOnObject>().setItem(_item);
                break;

            }

        }
    }

    public void test3(customEventData test) {
        Debug.Log(test.ID*4);
    }

    public void test4(customEventData test)
    {
        Debug.Log(test.ID * 8);
    }

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(inputManager.CharacterScreen)) {
            if (characterScreen.gameObject.activeSelf)
            {
                characterScreen.gameObject.SetActive(false);
            }
            else {
                characterScreen.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(inputManager.CraftingSystem))
        {
            if (craftSystem.gameObject.activeSelf)
            {
                craftSystem.gameObject.SetActive(false);
            }
            else
            {
                craftSystem.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(inputManager.Backpack))
        {
            if (backPack.gameObject.activeSelf)
            {
                backPack.gameObject.SetActive(false);
            }
            else
            {
                backPack.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(inputManager.Hotbar1))
        {
            hotbar(0);
            Debug.Log("Hotbar1");
        }
        if (Input.GetKeyDown(inputManager.Hotbar2))
        {
            hotbar(1);
            Debug.Log("Hotbar2");
        }
        if (Input.GetKeyDown(inputManager.Hotbar3))
        {
            hotbar(2);
            Debug.Log("Hotbar3");
        }
        if (Input.GetKeyDown(inputManager.Hotbar4))
        {
            hotbar(3);
            Debug.Log("Hotbar4");
        }
        if (Input.GetKeyDown(inputManager.Hotbar5))
        {
            hotbar(4);
            Debug.Log("Hotbar5");
        }
        if (Input.GetKeyDown(inputManager.Hotbar6))
        {
            hotbar(5);
            Debug.Log("Hotbar6");
        }
        if (Input.GetKeyDown(inputManager.Hotbar7))
        {
            hotbar(6);
            Debug.Log("Hotbar7");
        }
        if (Input.GetKeyDown(inputManager.Hotbar8))
        {
            hotbar(7);
            Debug.Log("Hotbar8");
        }
        if (Input.GetKeyDown(inputManager.Hotbar9))
        {
            hotbar(8);
            Debug.Log("Hotbar9");
        }
        if (Input.GetKeyDown(inputManager.Hotbar0))
        {
            hotbar(9);
            Debug.Log("Hotbar0");
        }
    }

    private ItemOnObject getItemOnObjectFromHotbar(int index) {
        if (hotBar.GetChild(0).GetChild(index).childCount > 0) {
            return hotBar.GetChild(0).GetChild(index).GetChild(0).GetComponent<ItemOnObject>();
        }
        return null;
    }

    private void hotbar(int HotbarID) {

        ItemOnObject equippedItemOnObject = getItemOnObjectFromHotbar(HotbarID);

        if (equippedItemOnObject != null) {
            if (equippedItemOnObject.getItem().Type == TypeItem.Weapon) {
                GameObject gameObject = Instantiate(equippedItemOnObject.getItem().Prefab);
                ItemWeapon itemWeapon = (ItemWeapon)equippedItemOnObject.getItem();

                itemWeapon.Stock = getCountFromInventory(itemWeapon.Ammo);

                gameObject.GetComponent<Weapon>().itemWeapon = itemWeapon;

                gameObject.transform.position = equipmentPoint.transform.position;
                gameObject.transform.rotation = equipmentPoint.transform.rotation;
                gameObject.transform.SetParent(equipmentPoint.transform);

                refreshAmmoInfo(itemWeapon);
            }
        }                 
    }

    public int getCountFromInventory(Item _item) {
        int Count = 0;

        for (int i = 0; i < backPack.GetChild(0).childCount; i++) {
            if (backPack.GetChild(0).GetChild(i).childCount > 0) {

                Debug.Log(backPack.GetChild(0).GetChild(i).name);

                ItemOnObject itemOnObject = backPack.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemOnObject>();

                if (itemOnObject.getItem().Name == _item.Name)
                {
                    Count = Count + itemOnObject.getItem().Stack;
                }
            }       
        }
        return Count;
    }

    public void WeaponReload(GameObject gameObject) {
     
        ItemWeapon itemWeapon = gameObject.GetComponent<Weapon>().itemWeapon;
        int AmmoStock = getCountFromInventory(itemWeapon.Ammo);
        itemWeapon.Stock = AmmoStock;
        itemWeapon.Loaded = itemWeapon.Ammo.ClipSize;
        itemWeapon.Stock--;
    }

    public void test2() {
        string asd = "";


        //for (int i = 0; i < backPack.GetChild(0).childCount; i++)
        //{
        //    if (backPack.GetChild(0).GetChild(i).childCount > 0)
        //    {

        //        ItemOnObject itemOnObject = backPack.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemOnObject>();

        //        asd = asd + "[1 "+itemOnObject.getItem().Name +" "+ itemOnObject.getItem().Stack+"]";

        //    }
        //}

        Debug.Log(asd);
        Debug.Log("EVENTMANAGER");
    }

    private void refreshAmmoInfo(ItemWeapon itemWeapon) {
        AmmoInfo ammoInfo = AmmoScreen.GetComponent<AmmoInfo>();
        ammoInfo.setAmmoInfoLoaded(itemWeapon.Loaded);
        ammoInfo.setAmmoInfoStock(itemWeapon.Stock);
    }
}