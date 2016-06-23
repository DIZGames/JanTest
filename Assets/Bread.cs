using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.ITSystem;
using System;
using Assets.EventSystem;

public class Bread : Consumable, IUsable {
    public void Action1() {


        EventManager.Instance.TriggerEvent(EventIdentifier.onConsumePlayer, new customEventData(itemConsumable));
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
