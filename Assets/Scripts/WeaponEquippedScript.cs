using UnityEngine;
using System.Collections;

public class WeaponEquippedScript : MonoBehaviour {

    private Item item;

    public Item getItem() {
        return item;
    }

    public void setItem(Item _item) {

        if (transform.childCount > 0) {
            Destroy(transform.GetChild(0));
        }

        this.item = _item;

        if (_item != null)
        {
            GameObject gObject = Instantiate(item.itemModel);
            gObject.transform.position = transform.position;
            gObject.transform.rotation = transform.rotation;
            gObject.transform.parent = transform;
        }
    }

	// Update is called once per frame
	void Update () {

        Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        

        if (item != null) {

            if (item.itemType == ItemType.Weapon)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    transform.GetChild(0).GetComponent<Weaponinterface>().primaryFire();
                    Debug.Log("PENG");
                }
            }
        }

        
	}
}
