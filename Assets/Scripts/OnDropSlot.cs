using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class OnDropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            Debug.Log("DROP");

            Debug.Log(transform.gameObject.name);

            if (DragHandeler.itemBeingDragged != null) {
                DragHandeler.itemBeingDragged.transform.SetParent(transform);
            }

           

            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, eventData, (x, y) => x.TakeItem());

        }
    }
}

