using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using Assets.ITSystem;

public class PlayerController_AddForce : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    private int count = 0;

    [SerializeField]
    private Transform Inventory;

    [SerializeField]
    private InputManager inputManager;

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

        if (Input.GetKey(inputManager.Up))
        {
            rb2d.AddForce(vectornew * Time.deltaTime * speed);
        }
        if (Input.GetKey(inputManager.Down))
        {
            rb2d.AddForce(-vectornew * Time.deltaTime * speed);
        }
        if (Input.GetKey(inputManager.Left))
        {
        
        }
        if (Input.GetKey(inputManager.Right))
        {
            
        }
    }
}

public interface IEquipmentChanged : IEventSystemHandler
{
    void refreshAmmo(int Loaded, int Stock);



}
