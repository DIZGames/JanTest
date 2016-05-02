using UnityEngine;
using System.Collections;

public class PlayerController_Translate : MonoBehaviour {

    public float speed;
    private Vector3 target;
    Vector3 lastPosition = Vector3.zero;
    private float rspeed;

    void Start()
    {

    }

    void FixedUpdate()
    {

        rspeed = (transform.position - lastPosition).magnitude * 100;
        lastPosition = transform.position;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
        transform.rotation = rot;

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);


        mousePos.z = transform.position.z;

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);

        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
       // anim.SetFloat("Speed", rspeed);
    }
}
