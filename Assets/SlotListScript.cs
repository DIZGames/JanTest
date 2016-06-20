using UnityEngine;
using System.Collections;
using Assets.ITSystem;

public class SlotListScript : MonoBehaviour {

    private GameObject SlotItem;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addItemToNextFreeSlot(Item _item) {
        SlotItem = (GameObject)Resources.Load("Prefabs/SlotItem");
        Debug.Log(SlotItem.name);


        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).childCount == 0) {
                transform.SetParent(transform.GetChild(i));

                GameObject gObject = Instantiate(SlotItem);
                gObject.transform.SetParent(transform.GetChild(i));
                gObject.transform.position = transform.GetChild(i).position;
                gObject.GetComponent<ItemOnObject>().setItem(_item);

                break;

            }


        }
    }

    public Transform getNextFreeSlot() {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount == 0)
            {
                return transform.GetChild(i);
            }
        }
        return null;
    }
}
