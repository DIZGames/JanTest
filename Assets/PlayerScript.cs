using UnityEngine;
using System.Collections;
using Assets.ITSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Assets.EventSystem;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
    InputManager inputManager;
    [SerializeField]
    Transform equipmentPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(inputManager.Fire1))
        {
            if (equipmentPoint.childCount > 0) {
                equipmentPoint.GetChild(0).GetComponent<IUsable>().Action1();
            }   
        }
        if (Input.GetKeyDown(inputManager.Fire2))
        {
            if (equipmentPoint.childCount > 0)
            {
                equipmentPoint.GetChild(0).GetComponent<IUsable>().Action2();
            }
        }
        if (Input.GetKeyDown(inputManager.Reload))
        {
            if (transform.GetChild(0).childCount > 0)
            {
                transform.GetChild(0).GetChild(0).GetComponent<IUsable>().Reload();
            }
        }
    }
}
