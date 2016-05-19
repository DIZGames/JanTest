using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour {

    [SerializeField]
    public Item item;

	// Use this for initialization
	void Start () {
        item = null;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setItem(Item item) {

        Debug.Log("Set Item " + item.itemName);
        this.item = item;
        setIcon(item.itemIcon);

    }



    public Item getItem() {
        return item;
    }

    public void clearSlot() {
        item = null;
        setIcon(null);
        
    }

    private void setIcon(Sprite sprite) {
        gameObject.transform.GetComponent<Image>().sprite = sprite;
        
    }

    public bool isFree() {
        if (item == null)
        {
            Debug.Log("true");
            return true;

        }
        return false;
    }

    //public void SelectImage(GameObject gameobject) {


    //    Debug.Log(gameObject.name);
    //    GetComponent<Image>().color = Color.cyan;
    //}


    
}
