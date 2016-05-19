using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

public class RocketLauncherScript : MonoBehaviour, Weaponinterface
{
    public Transform FirePoint;

    [SerializeField]
    private Weapon RocketLauncher;

    
    public void test()
    {
        Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(FirePoint.position.x, FirePoint.position.y);

        // Berechnet Vektor vom Spieler zur Maus
        Vector2 vectornew = mouseposition - firePointPosition;
        // Normalisiert den Vektor
        vectornew.Normalize();

        GameObject t = GameObject.Instantiate(RocketLauncher.Ammo.itemModel);
        t.transform.position = FirePoint.position;
        t.transform.rotation = FirePoint.rotation;
        t.gameObject.name = "Rocket";


        Debug.Log(mouseposition.x.ToString() + " " + mouseposition.y.ToString());

        t.gameObject.GetComponent<Rigidbody2D>().AddForce(vectornew * RocketLauncher.bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);


    }

    public void primaryFire()
    {
        test();
    }

    public void secondaryFire()
    {
        throw new NotImplementedException();
    }
}
