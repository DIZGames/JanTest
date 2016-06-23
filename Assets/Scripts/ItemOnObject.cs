using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.ITSystem;
using UnityEngine.EventSystems;
using Assets.EventSystem;

public class ItemOnObject : MonoBehaviour {

    [SerializeField]
    private Item _Item;

    void Start() {
        EventManager.Instance.AddListener(EventIdentifier.onRefreshSlot, (customEventData) => { refreshTile(); });
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
        if (_Item.Stack != 0) {
            transform.GetChild(0).GetComponent<Image>().sprite = _Item.Icon;
            transform.GetChild(1).GetComponent<Text>().text = _Item.Stack.ToString();
        }
        else {
            destroyObject();
        }

        
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
