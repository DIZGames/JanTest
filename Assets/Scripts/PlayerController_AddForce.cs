using UnityEngine;
using System.Collections;

public class PlayerController_AddForce : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private int count = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        //Für Rotation

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log("MousePos:"+mousePos.x.ToString()+" ##### "+ mousePos.y.ToString());

        Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
        transform.rotation = rot;

        Vector2 vectornew = new Vector2(mousePos.x, mousePos.y);

       


        if (Input.GetKey("w"))
        {
            rb2d.AddForce(vectornew * speed * Time.deltaTime);

            //rb2d.AddForce(Vector2.MoveTowards(transform.position, transform.forward, speed * Time.deltaTime));
        }
        if (Input.GetKey("a"))
        {
          
        }
        if (Input.GetKey("d"))
        {
        
        }
        if (Input.GetKey("s"))
        {
            rb2d.AddForce(vectornew * speed*-1* Time.deltaTime);
        }


        ////transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //////charRigidbody.angularVelocity = 0;

        ////mousePos.z = transform.position.z;
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        ////Debug.Log(movement.x.ToString()+movement.y.ToString());

        //rb2d.AddForce(movement * speed);
    }
}
