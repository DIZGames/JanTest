using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.ITSystem;
using Assets.EventSystem;

public class OnDropCharacterSlot : MonoBehaviour, IDropHandler {

    [SerializeField]
    private TypeClothing allowedClothingType;

    [SerializeField]
    private EventIdentifier OnDropEvent;

    private bool isAllowed(Item item) {
        ItemClothing itemClothing = (ItemClothing)item;

        if (itemClothing.Type == TypeItem.Clothing && itemClothing.TypeClothing == allowedClothingType) {
            return true;
        }
        return false;
    }


    public void OnDrop(PointerEventData eventData) {

        if (eventData.pointerDrag != null && isAllowed(eventData.pointerDrag.gameObject.GetComponent<ItemOnObject>().getItem())) {
            if (transform.childCount == 0) {  //Wenn Slot leer
                                              //if (eventData.pointerDrag != null)
                                              //{
                eventData.pointerDrag.transform.SetParent(transform);
                //}
            }
            else if (transform.childCount > 0) {   //Wenn Slot bereits ein ItemSlot besitzt
                                                   //if (eventData.pointerDrag != null)
                                                   //{

                ItemOnObject draggedItem = eventData.pointerDrag.GetComponent<ItemOnObject>();
                ItemOnObject slotItem = transform.GetChild(0).GetComponent<ItemOnObject>();

                if (draggedItem.getItem().Name == slotItem.getItem().Name && (slotItem.getItem().Stack != slotItem.getItem().MaxStack || draggedItem.getItem().Stack != slotItem.getItem().MaxStack)) { //Wenn beide Items identisch sind und keiner der beiden Stapel Maxstapel haben
                    int freeCount = slotItem.getItem().MaxStack - slotItem.getItem().Stack;

                    if (draggedItem.getItem().Stack <= freeCount) {
                        slotItem.getItem().Stack = slotItem.getItem().Stack + draggedItem.getItem().Stack;
                        draggedItem.destroyObject();
                    }
                    else {
                        int rest = draggedItem.getItem().Stack - freeCount;
                        slotItem.getItem().Stack = slotItem.getItem().MaxStack;
                        draggedItem.getItem().Stack = rest;
                    }

                }
                else { //SWAP
                    Item item = draggedItem.getItem();
                    draggedItem.setItem(slotItem.getItem());
                    slotItem.setItem(item);

                }

                draggedItem.refreshTile();
                slotItem.refreshTile();
            }

        }
        EventManager.Instance.TriggerEvent(OnDropEvent, new customEventData(eventData.pointerDrag.gameObject.GetComponent<ItemOnObject>().getItem()));
    }
}
