using UnityEngine;
using System.Collections;

public class PlayerInventar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public Transform Inventar;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {

            Inventar.gameObject.SetActive(true);
         
        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            Inventar.gameObject.SetActive(false);

        }
    }
}
