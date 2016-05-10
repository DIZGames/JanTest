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

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Rotation
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
        transform.rotation = rot;

        // Berechnet Vektor vom Spieler zur Maus
        Vector2 vectornew = mousePos - transform.position;
        // Normalisiert den Vektor
        vectornew.Normalize();

        if (Input.GetKey("w"))
        {
            rb2d.AddForce(vectornew * Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {
          
        }
        if (Input.GetKey("d"))
        {
        
        }
        if (Input.GetKey("s"))
        {
            rb2d.AddForce(-vectornew * Time.deltaTime * speed);
        }
    }
}
