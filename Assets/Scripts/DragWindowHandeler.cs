using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragWindowHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Vector3 startPosition;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {

        startPosition = transform.position;
        startParent = transform.parent;

        transform.parent.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
