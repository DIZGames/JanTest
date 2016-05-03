using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class WeaponSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public Transform Item1;
    public Transform Item2;
    

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Keypad1)) {

            
            Transform t;
            t = GameObject.Instantiate(Item1);
            t.position = transform.position;
            t.rotation = transform.rotation;
            t.parent = transform;
            t.gameObject.name = "Item1";
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)){


            Transform t = GameObject.Instantiate(Item2);
            t.position = transform.position;
            t.rotation = transform.rotation;
            t.parent = transform;
            t.gameObject.name = "Item2";
        }

    }
}
