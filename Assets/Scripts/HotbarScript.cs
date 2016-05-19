using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class HotbarScript : MonoBehaviour {

    [SerializeField]
    private Transform EquipmentPoint;

    [SerializeField]
    private KeyCode[] SlotCodes = new KeyCode[10];

    void Update() {

        for (int i = 0; i < SlotCodes.Length; i++) {
            if (Input.GetKeyDown(SlotCodes[i])) {

                resetColorOfSlot();
                setSelectedColor(transform.GetChild(0).GetChild(i));

                EquipmentPoint.GetComponent<WeaponEquippedScript>().setItem(transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemOnObject>().getItem());

            }

        }

    }





    private void resetColorOfSlot() {
        for (int i = 0; i < SlotCodes.Length; i++)
        {
                transform.GetChild(0).GetChild(i).GetComponent<Image>().color = Color.white;
        }
    }

    private void setSelectedColor(Transform slot) {
        slot.GetComponent<Image>().color = Color.cyan;
    }

    private void resetEquipmentPoint() {


        if (EquipmentPoint.childCount > 0) {
            Transform asd = EquipmentPoint.GetChild(0);
            Destroy(asd.gameObject);
        }
        
    }

    private void SetSlotItemToEquipped(Transform slot) {
        Item item = slot.GetChild(0).GetComponent<ItemOnObject>().getItem();

      

        Debug.Log("SetSlotItemToEquipped"+item.name);

        if (item != null) {
            Debug.Log("SetSlotItemToEquipped___!!!");
            GameObject _item = Instantiate(item.itemModel);


            _item.transform.position = EquipmentPoint.position;
            _item.transform.rotation = EquipmentPoint.rotation;
            _item.transform.parent = EquipmentPoint;
        }
    }
}
