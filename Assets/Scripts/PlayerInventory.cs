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
    private Transform backPack;
    [SerializeField]
    private Transform hotBar;
    [SerializeField]
    private Transform characterScreen;
    [SerializeField]
    private Transform craftSystem;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject SlotItem;
    [SerializeField]
    private Transform Player;

    private PlayerScript playerScript;

    private ItemOnObject equippedItemOnObject;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();

        EventManager.Instance.AddListener(EventIdentifier.onSplitItem, (customEventData) => { addNewItemToInventory(customEventData.Item); });
        EventManager.Instance.AddListener(EventIdentifier.onReloadWeapon, (customEventData) => { Reload(customEventData.Item); });
        EventManager.Instance.AddListener(EventIdentifier.onSetBlock, (customEventData) => { SetBlock(customEventData.Item); });

        EventManager.Instance.AddListener(EventIdentifier.OnDropBackpack,(customEventData) => { refreshSlotlist(backPack.GetChild(0)); });
        EventManager.Instance.AddListener(EventIdentifier.OnDropChracterScreen, (customEventData) => { refreshSlotlist(characterScreen.GetChild(0)); });
        EventManager.Instance.AddListener(EventIdentifier.OnDropHotbar, (customEventData) => { refreshSlotlist(hotBar.GetChild(0)); });

    }

    private void refreshSlotlist(Transform slotList) {
        for (int i = 0; i < slotList.childCount; i++) {
            if (slotList.GetChild(i).childCount > 0) {
                slotList.GetChild(i).GetChild(0).GetComponent<ItemOnObject>().refreshTile();
            }
        }
    }

    void Update() {


        if (Input.GetKeyDown(inputManager.CharacterScreen)) {
            if (characterScreen.gameObject.activeSelf) {
                characterScreen.gameObject.SetActive(false);
            }
            else {
                characterScreen.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(inputManager.CraftingSystem)) {
            if (craftSystem.gameObject.activeSelf) {
                craftSystem.gameObject.SetActive(false);
            }
            else {
                craftSystem.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(inputManager.Backpack)) {
            if (backPack.gameObject.activeSelf) {
                backPack.gameObject.SetActive(false);
            }
            else {
                backPack.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(inputManager.Hotbar1)) {
            hotbar(0);
        }
        if (Input.GetKeyDown(inputManager.Hotbar2)) {
            hotbar(1);
        }
        if (Input.GetKeyDown(inputManager.Hotbar3)) {
            hotbar(2);
        }
        if (Input.GetKeyDown(inputManager.Hotbar4)) {
            hotbar(3);
        }
        if (Input.GetKeyDown(inputManager.Hotbar5)) {
            hotbar(4);
        }
        if (Input.GetKeyDown(inputManager.Hotbar6)) {
            hotbar(5);
        }
        if (Input.GetKeyDown(inputManager.Hotbar7)) {
            hotbar(6);
        }
        if (Input.GetKeyDown(inputManager.Hotbar8)) {
            hotbar(7);
        }
        if (Input.GetKeyDown(inputManager.Hotbar9)) {
            hotbar(8);
        }
        if (Input.GetKeyDown(inputManager.Hotbar0)) {
            hotbar(9);
        }
    }

    private void SetBlock(Item _item) {
        if (_item.Stack > 1) {
            _item.Stack--;

            EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshSlot, new customEventData());

            GameObject _gameObject = Instantiate(equippedItemOnObject.getItem().Prefab);
            ItemBlock itemBlock = (ItemBlock)equippedItemOnObject.getItem();

            _gameObject.GetComponent<Block>().itemBlock = itemBlock;
            playerScript.setEquipment(_gameObject);
        }
        else {
            equippedItemOnObject.destroyObject();
        }

    }

    public void addNewItemToInventory(Item item) {
        Transform transform = getNextFreeSlot();
        if (transform != null) {

            GameObject go = Instantiate(SlotItem);
            go.GetComponent<ItemOnObject>().setItem(item);
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.transform.SetParent(transform);
        }
    }

    public void addItemToInventory(Item item) {

    }

    public ItemOnObject getItemFromInvetory(Item item) {

        for (int i = 0; i < backPack.GetChild(0).childCount; i++) {
            if (backPack.GetChild(0).GetChild(i).childCount > 0) {
                ItemOnObject itemOnObject = backPack.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemOnObject>();
                if (item.Name == backPack.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemOnObject>().getItem().Name) {
                    return itemOnObject;
                }
            }
        }
        return null;
    }

    private ItemOnObject getItemOnObjectFromHotbar(int index) {
        if (hotBar.GetChild(0).GetChild(index).childCount > 0) {
            return hotBar.GetChild(0).GetChild(index).GetChild(0).GetComponent<ItemOnObject>();
        }
        return null;
    }

    private Transform getNextFreeSlot() {

        //BackPack
        for (int i = 0; i < backPack.GetChild(0).childCount; i++) {
            if (backPack.GetChild(0).GetChild(i).childCount == 0) {
                return backPack.GetChild(0).GetChild(i);
            }
        }
        //Hotbar
        for (int j = 0; j < hotBar.GetChild(0).childCount; j++){
            if (hotBar.GetChild(0).GetChild(j).childCount == 0){
                return hotBar.GetChild(0).GetChild(j);
            }
        }

        return null;
    }

    private void hotbar(int HotbarID) {

        equippedItemOnObject = getItemOnObjectFromHotbar(HotbarID);

        if (equippedItemOnObject != null) {
            Item item = equippedItemOnObject.getItem();

            if (item != null) {
                if (item.Type == TypeItem.Weapon) {
                    ItemWeapon itemWeapon = (ItemWeapon)item;

                    GameObject gameObject = Instantiate(itemWeapon.Prefab);
 
                    itemWeapon.Stock = getCountFromInventory(itemWeapon.Ammo);

                    gameObject.GetComponent<Weapon>().itemWeapon = itemWeapon;

                    playerScript.setEquipmentOnPoint(gameObject);

                    EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshAmmoInfo,new customEventData(itemWeapon));
                    EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshSlot, new customEventData());
                }
                if (item.Type == TypeItem.Block) {                  
                    ItemBlock itemBlock = (ItemBlock)item;

                    GameObject gameObject = Instantiate(itemBlock.Prefab);

                    gameObject.GetComponent<Block>().itemBlock = itemBlock;

                    playerScript.setEquipment(gameObject);
                }
                if (item.Type == TypeItem.Consumable) {
                    ItemConsumable itemConsumable = (ItemConsumable)item;

                    GameObject gameObject = Instantiate(itemConsumable.Prefab);

                    gameObject.GetComponent<Consumable>().itemConsumable = itemConsumable;

                    playerScript.setEquipmentOnPoint(gameObject);
                }
            }
        }                 
    }

    private int getCountFromInventory(Item _item) {
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

    private void increaseStackFromItemInInventory(Item item) {
        ItemOnObject itemOnObject = getItemFromInvetory(item);
        if (itemOnObject != null) {

            itemOnObject.getItem().Stack++;
        }
    }

    private void decreaseStackFromItemInInventory(Item item) {
        ItemOnObject itemOnObject = getItemFromInvetory(item);
        if (itemOnObject != null) {
            if (itemOnObject.getItem().Stack > 1) {
                itemOnObject.getItem().Stack--;
            }
            else {
                itemOnObject.destroyObject();
            }    
        }
    }

    private void Reload(Item item) {

        if (item.Type == TypeItem.Weapon) {
            ItemWeapon itemWeapon = (ItemWeapon)item;

            itemWeapon.Stock = getCountFromInventory(itemWeapon.Ammo);
            if (itemWeapon.Stock >= 1) {
                if (itemWeapon.Loaded < itemWeapon.Ammo.ClipSize) {
                    itemWeapon.Stock--;
                    itemWeapon.Loaded = itemWeapon.Ammo.ClipSize;
                    decreaseStackFromItemInInventory(itemWeapon.Ammo);
                    EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshAmmoInfo, new customEventData(itemWeapon));
                    EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshSlot, new customEventData());
                }
            }       
        }

        EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshSlot,new customEventData());


    }
}