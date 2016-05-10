using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HotbarScript : MonoBehaviour {


    public KeyCode[] keyCodesForSlots = new KeyCode[10];
    public Transform Player;
    private ItemList itemList;
    private Item activeItem;
    private Transform activeObject;
    private List<Item> HotbarList;

    // Use this for initialization
    void Start () {
        itemList = (ItemList)Resources.Load("ItemDatabase");
        activeItem = new Item();


        SetItemOnHotbarSlot(1, itemList.getItemByID(0));
        SetItemOnHotbarSlot(2, itemList.getItemByID(1));


    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 10; i++) {
            if (Input.GetKeyDown(keyCodesForSlots[i]))
            {
                activeItem = null;
                if (activeObject != null) {
                    activeObject.parent = null;
                    Destroy(activeObject);
                }
                

                //Initialize Item and set it as active
                activeItem = GetItemFromHotbarSlot(i);

                activeObject = Instantiate(activeItem.itemModel.transform) as Transform;
                activeObject.parent = Player.transform; // group the instance under the spawner
                activeObject.localPosition = Vector3.zero; // make it at the exact position of the spawner
                activeObject.localRotation = Quaternion.identity; // same for rotation

                //
                Debug.Log("1 activeItem: "+activeItem.itemName+" activeObject: " + activeObject.gameObject.name);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("2 activeItem: " + activeItem.itemName + " activeObject: " + activeObject.gameObject.name);
            if (activeItem.itemType == ItemType.Weapon)
            {
                Debug.Log("3 activeItem: " + activeItem.itemName + " activeObject: " + activeObject.gameObject.name);
                activeItem.itemModel.GetComponent<WeaponInterface>().test();
                Debug.Log("4 activeItem: " + activeItem.itemName + " activeObject: " + activeObject.gameObject.name);
            }


        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (activeItem.itemType == ItemType.Weapon)
            {
                activeObject.GetComponent<WeaponInterface>().test();
            }
        }


    }


    public void SetItemOnHotbarSlot(int index, Item item) {
        transform.GetChild(0).GetChild(index).GetComponent<SlotScript>().setItemInSlot(item);
    }

    public Item GetItemFromHotbarSlot(int index)
    {
        return transform.GetChild(0).GetChild(index).GetComponent<SlotScript>().getItemInSlot();
    }
}
