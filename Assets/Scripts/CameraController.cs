using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CameraController : MonoBehaviour,IPointerDownHandler {

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Test");
    }
}
