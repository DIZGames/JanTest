using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemOnObject : MonoBehaviour {

    [SerializeField]
    private Item item;                                       //Item 

    public Item getItem() {
        Debug.Log("GETITEM:"+item.itemName);
        return item;
    }

    public void setItem(Item _item) {
        this.item = _item;

        Debug.Log("GETITEM:" + item.itemName);

        transform.GetChild(0).GetComponent<Image>().sprite = _item.itemIcon;
        transform.GetChild(1).GetComponent<Text>().text = _item.itemValue.ToString();
        Debug.Log(_item.itemName);
    }



}
