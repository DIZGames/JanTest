using UnityEngine;
using System.Collections;
using Assets.ITSystem;
using System;
using UnityEngine.EventSystems;
using Assets.Scripts;
using Assets.EventSystem;

public class RocketLauncherScript : Weapon, IUsable{

    // Use this for initialization
    void Start()
    {
        FirePoint = transform.GetChild(0);
    }

    public void Action1()
    {
        if (itemWeapon.Loaded >= 1)
        {
            itemWeapon.Loaded--;
            Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 firePointPosition = new Vector2(FirePoint.position.x, FirePoint.position.y);

            // Berechnet Vektor vom Spieler zur Maus
            Vector2 vectornew = mouseposition - firePointPosition;
            // Normalisiert den Vektor
            vectornew.Normalize();

            GameObject t = GameObject.Instantiate(itemWeapon.Ammo.Prefab);
            t.transform.position = FirePoint.position;
            t.transform.rotation = FirePoint.rotation;
            t.gameObject.name = "Rocket";

            Debug.Log(mouseposition.x.ToString() + " " + mouseposition.y.ToString());

            t.gameObject.GetComponent<Rigidbody2D>().AddForce(vectornew * itemWeapon.BulletSpeed * Time.deltaTime, ForceMode2D.Impulse);

            EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshAmmoInfo, new customEventData(itemWeapon));
        }
    }

    public void Action2()
    {
     
    }

    public void Reload()
    {
        EventManager.Instance.TriggerEvent(EventIdentifier.onReloadWeapon, new customEventData(itemWeapon));
        EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshAmmoInfo, new customEventData(itemWeapon));
    }

    public void Destroy()
    {
        throw new NotImplementedException();
    }
}
