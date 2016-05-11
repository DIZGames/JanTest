using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class HotbarScript : MonoBehaviour {


    public KeyCode[] keyCodesForSlots = new KeyCode[10];
    public Transform Player;
    private ItemList itemList;
    private Item activeItem;
    private Transform activeObject;


    // Use this for initialization
    void Start () {
        itemList = (ItemList)Resources.Load("ItemDatabase");
        activeItem = new Item();

        keyCodesForSlots[0] = KeyCode.Alpha0;
        keyCodesForSlots[1] = KeyCode.Alpha1;
        keyCodesForSlots[2] = KeyCode.Alpha2;
        keyCodesForSlots[3] = KeyCode.Alpha3;
        keyCodesForSlots[4] = KeyCode.Alpha4;
        keyCodesForSlots[5] = KeyCode.Alpha5;
        keyCodesForSlots[6] = KeyCode.Alpha6;
        keyCodesForSlots[7] = KeyCode.Alpha7;
        keyCodesForSlots[8] = KeyCode.Alpha8;
        keyCodesForSlots[9] = KeyCode.Alpha9;
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 10; i++) {
            if (Input.GetKeyDown(keyCodesForSlots[i]))
            {
                Debug.Log("Key "+i.ToString());

                activeItem = null;
                if (activeObject != null) {
                    activeObject.parent = null;
                    Destroy(activeObject);
                }
                

                //Initialize Item and set it as active
                //activeItem = GetItemFromHotbarSlot(i);

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

   

    //public void onPointerEnterSlot(GameObject _gameobject) {
    //   Debug.Log("Enter: "+_gameobject.GetComponent<SlotScript>().gameObject.name);
    //}

    //public void onPointerDownSlot(GameObject _gameobject)
    //{
    //    Debug.Log("Down: " + _gameobject.GetComponent<SlotScript>().gameObject.name);
    //}



}
