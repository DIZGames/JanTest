using UnityEngine;
using System.Collections;

public class WeaponEquippedScript : MonoBehaviour {

    public Transform getItem() {
        return transform.GetChild(0);
    }

    public void setItem(Transform trans) {
        Destroy(transform.GetChild(0));

        trans.SetParent(transform);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
