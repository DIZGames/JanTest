using UnityEngine;
using System.Collections;

public class UI_Control : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}

    public void Click() {

        if (player.GetComponent<PlayerController_AddForce>().enabled == false)
        {
            player.GetComponent<PlayerController_AddForce>().enabled = true;
            player.GetComponent<PlayerController_Translate>().enabled = false;
        }
        else {
            player.GetComponent<PlayerController_AddForce>().enabled = false;
            player.GetComponent<PlayerController_Translate>().enabled = true;
        }

        

        Debug.Log("HALLO");
    }
}
