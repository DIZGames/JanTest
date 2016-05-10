using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private Item item;

    public void SelectImage() {

        Debug.Log("ImageSelected!");
        GetComponent<Image>().color = Color.cyan;



    }

    public void setItemInSlot(Item item)
    {
        this.item = item;
        setSourceImage(item.itemIcon);
    }

    public Item getItemInSlot() {
        return item;
    }

    private void setSourceImage(Sprite ItemSprite) {
        GetComponent<Image>().sprite = ItemSprite;
    }
    
    
}
