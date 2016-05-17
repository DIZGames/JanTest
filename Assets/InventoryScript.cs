using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I)) {
            Debug.Log(gameObject.activeSelf);
            if (gameObject.activeSelf)
            {
                Debug.Log("Enabled");
                gameObject.SetActive(false);

            }
            else {
                Debug.Log("Disabled");
                gameObject.SetActive(true);
            }
        }
	}
}
