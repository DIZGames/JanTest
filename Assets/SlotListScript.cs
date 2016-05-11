using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotListScript : MonoBehaviour {

    private ItemList itemList;

    // Use this for initialization
    void Start () {
        itemList = (ItemList)Resources.Load("ItemDatabase");
        Debug.Log("STARTSLOTLIST"+itemList);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setItemOnNextFreeSlot(Item item) {
        Debug.Log("childCount: " + transform.childCount);
        for (int i = 0; i < transform.childCount; i++) {
            if (isFreeOnIndex(i)) {
                Debug.Log("11item: " + item.itemName);
                transform.GetChild(i).GetComponent<Image>().sprite = item.itemIcon;
                
                break;
            }
        }
    }

    public void setItemOnSlot(int index, Item item) {
        transform.GetChild(index).GetComponent<Image>().sprite = item.itemIcon;
    }

    public bool isFreeOnIndex(int index) {

        if (transform.GetChild(index).GetComponent<Image>().sprite == null) {
            Debug.Log("true");
            return true;
            
        }
        Debug.Log("false");
        return false;
    }

    public void addById(int itemID, int itemValue)
    {
        itemList = (ItemList)Resources.Load("ItemDatabase");
        Debug.Log("List: " + itemList.itemList.Count);

        Item item = itemList.getItemByID(itemID);

        Debug.Log("item: " + item.itemName);

        Debug.Log(transform.GetChild(0).name);

        //setItemOnSlot(0, item);
        setItemOnNextFreeSlot(item);

        Debug.Log("Zu Hotbar hinzugefügt: " + itemID);
    }
}
