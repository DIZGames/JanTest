using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float zSpeed;

    void LateUpdate()
    {

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + Input.GetAxis("Mouse ScrollWheel") * 100, Time.deltaTime * zSpeed);
    }
}
