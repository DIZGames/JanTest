using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using Assets.EventSystem;
using Assets.ITSystem;

public class SplitItem : MonoBehaviour, IPointerDownHandler
{
    private bool isPressed = false;

    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject SlotList;
    [SerializeField]
    private GameObject SlotItem;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && isPressed) {
            ItemOnObject itemOnObject = transform.GetComponent<ItemOnObject>();

            if (itemOnObject.getItem().Stack > 1) {
                int modulo = 0;

                if (itemOnObject.getItem().Stack % 2 == 1) {
                    modulo = 1;
                }

                int result = itemOnObject.getItem().Stack / 2;
                itemOnObject.getItem().Stack = result + modulo;


                Item _item = itemOnObject.getItem().getCopy();
                _item.Stack = result;

                EventManager.Instance.TriggerEvent(EventIdentifier.onSplitItem, new customEventData(_item));

                //ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, eventData, (x, y) => x.addToInventory(itemOnObject.getItem(), result));


            }
            itemOnObject.refreshTile();

            Debug.Log("Splititem selection");
        }
        if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log("Right click");
        }     
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(inputManager.Splititem)){
            Debug.Log("ispressed true");
            isPressed = true;
        }
        if (Input.GetKeyUp(inputManager.Splititem))
        {
            Debug.Log("ispressed false");
            isPressed = false;
        }
    }
}
