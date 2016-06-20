using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.ITSystem;
using UnityEngine.EventSystems;

public class ItemOnObject : MonoBehaviour {

    [SerializeField]
    private Item _Item;
    [SerializeField]
    private int Count;

    void Start() {

    }

    public Item getItem() {
        if (_Item != null) {
            refreshTile();
        }
        return _Item;
    }

    public void setItem(Item item) {      
        _Item = item;
        refreshTile();
    }

    public void refreshTile() {
        transform.GetChild(0).GetComponent<Image>().sprite = _Item.Icon;
        transform.GetChild(1).GetComponent<Text>().text = _Item.Stack.ToString();
    }

    public void destroyObject() {
        Destroy(gameObject);
    }

    public void decreaseStack(int count) {
        _Item.Stack = _Item.Stack - count;
        if (_Item.Stack == 0) {
            destroyObject();
        }
    }

    public void increaseStack(int count) {
        _Item.Stack = _Item.Stack + count;
    }







}
