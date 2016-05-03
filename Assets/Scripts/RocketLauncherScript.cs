using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

public class RocketLauncherScript : MonoBehaviour, WeaponInterface {

    public Transform Bullet;
    public float BulletSpeed;
    
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void shoot()
    {

        Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(transform.position.x, transform.position.y);


        Transform t = GameObject.Instantiate(Bullet);
        t.position = transform.position;
        t.rotation = transform.rotation;
        t.gameObject.name = "Rocket";

        Bullet.GetComponent<Rigidbody2D>().AddForce(mouseposition * BulletSpeed * Time.deltaTime);

        Debug.Log("Hallo");
    }
}
