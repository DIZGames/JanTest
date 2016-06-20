using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using Assets.ITSystem;

public class OnDropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private TypeItem[] allowedItemTypes;

    private bool isAllowed(Item item) {
        if (allowedItemTypes.Length == 0){
            return true;
        }
        else {
            for (int i = 0; i < allowedItemTypes.Length; i++) {
                if (allowedItemTypes[i] == item.Type) {
                    return true;
                }
            }
            return false;
        }

    }


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && isAllowed(eventData.pointerDrag.gameObject.GetComponent<ItemOnObject>().getItem())) {
            if (transform.childCount == 0)
            {  //Wenn Slot leer
                //if (eventData.pointerDrag != null)
                //{
                    eventData.pointerDrag.transform.SetParent(transform);
                //}
            }
            else if (transform.childCount > 0)
            {   //Wenn Slot bereits ein ItemSlot besitzt
                //if (eventData.pointerDrag != null)
                //{

                    ItemOnObject draggedItem = eventData.pointerDrag.GetComponent<ItemOnObject>();
                    ItemOnObject slotItem = transform.GetChild(0).GetComponent<ItemOnObject>();

                    if (draggedItem.getItem().Name == slotItem.getItem().Name && (slotItem.getItem().Stack != slotItem.getItem().MaxStack || draggedItem.getItem().Stack != slotItem.getItem().MaxStack))
                    { //Wenn beide Items identisch sind und keiner der beiden Stapel Maxstapel haben
                        int freeCount = slotItem.getItem().MaxStack - slotItem.getItem().Stack;

                        if (draggedItem.getItem().Stack <= freeCount)
                        {
                            slotItem.getItem().Stack = slotItem.getItem().Stack + draggedItem.getItem().Stack;
                            draggedItem.destroyObject();
                        }
                        else
                        {
                            int rest = draggedItem.getItem().Stack - freeCount;
                            slotItem.getItem().Stack = slotItem.getItem().MaxStack;
                            draggedItem.getItem().Stack = rest;
                        }

                    }
                    else
                    { //SWAP
                        Item item = draggedItem.getItem();
                        draggedItem.setItem(slotItem.getItem());
                        slotItem.setItem(item);

                    }

                    draggedItem.refreshTile();
                    slotItem.refreshTile();
                }

            //}

        }

        

        //ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());

    }
}

