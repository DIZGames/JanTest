using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.ITSystem;
using System;
using Assets.EventSystem;

public class OnDropHotbar : MonoBehaviour, IDropHandler {

    [SerializeField]
    private TypeItem[] allowedItemTypes;

    [SerializeField]
    private EventIdentifier OnDropEvent;

    private bool isAllowed(Item item)
    {
        if (allowedItemTypes.Length == 0)
        {
            return true;
        }
        else
        {
            for (int i = 0; i < allowedItemTypes.Length; i++)
            {
                if (allowedItemTypes[i] == item.Type)
                {
                    return true;
                }
            }
            return false;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Weaopn");

        if (eventData.pointerDrag != null) {
            ItemOnObject draggedItem = eventData.pointerDrag.GetComponent<ItemOnObject>();
            ItemOnObject slotItem = transform.GetComponent<ItemOnObject>();

            if (slotItem.getItem().Type == TypeItem.Weapon && draggedItem.getItem().Type == TypeItem.Ammo) {
                ItemWeapon wpItem = (ItemWeapon)slotItem.getItem();
                ItemAmmo amItem = (ItemAmmo)draggedItem.getItem();

                if (wpItem.Ammo.Name == amItem.Name) {

                    eventData.pointerDrag.transform.rotation = transform.rotation;
                    eventData.pointerDrag.transform.SetParent(transform);
                   
                }

            }

        }
        EventManager.Instance.TriggerEvent(OnDropEvent, new customEventData(eventData.pointerDrag.gameObject.GetComponent<ItemOnObject>().getItem()));
    }
}
