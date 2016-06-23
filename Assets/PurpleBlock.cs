using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.ITSystem;
using System;
using Assets.EventSystem;

public class PurpleBlock : Block, IUsable {

    private bool flag;

    public void Action1() {

        flag = false;
        transform.SetParent(null);
        EventManager.Instance.TriggerEvent(EventIdentifier.onSetBlock, new customEventData(itemBlock));
               
    }

    public void Action2() {
        throw new NotImplementedException();
    }

    public void Reload() {
        throw new NotImplementedException();


    }

    // Use this for initialization
    void Start () {
      
	}

    void Awake() {
        flag = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (flag) {
            Vector2 vector = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            transform.position = vector;
        }
           
    }
}
