using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

public class RocketLauncherScript : MonoBehaviour, WeaponInterface
{
    public Transform FirePoint;
    public Transform Bullet;
    public float BulletSpeed;
    
    public void test()
    {
        Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(FirePoint.position.x, FirePoint.position.y);

        // Berechnet Vektor vom Spieler zur Maus
        Vector2 vectornew = mouseposition - firePointPosition;
        // Normalisiert den Vektor
        vectornew.Normalize();

        Transform t = GameObject.Instantiate(Bullet);
        t.position = FirePoint.position;
        t.rotation = FirePoint.rotation;
        t.gameObject.name = "Rocket";

        Debug.Log(mouseposition.x.ToString() + " " + mouseposition.y.ToString());

        t.gameObject.GetComponent<Rigidbody2D>().AddForce(vectornew * BulletSpeed * Time.deltaTime, ForceMode2D.Impulse);

        Debug.Log("Hallo");
    }
}
