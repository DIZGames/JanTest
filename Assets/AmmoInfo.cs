using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.EventSystem;
using Assets.ITSystem;

public class AmmoInfo : MonoBehaviour {


    void Start() {
        EventManager.Instance.AddListener(EventIdentifier.onRefreshAmmoInfo,(customEventData) => { setAmmoInfo(customEventData.Item); });
    }

    private void setAmmoInfo(Item item) {
        if (item.Type == TypeItem.Weapon) {
            ItemWeapon itemweapon = (ItemWeapon)item;
            transform.GetChild(0).GetComponent<Text>().text = itemweapon.Loaded.ToString();
            transform.GetChild(1).GetComponent<Text>().text = itemweapon.Stock.ToString();
        }
        if (item.Type == TypeItem.Tool) {
            ItemTool itemtool = (ItemTool)item;
            transform.GetChild(0).GetComponent<Text>().text = itemtool.Loaded.ToString();
            transform.GetChild(1).GetComponent<Text>().text = itemtool.Stock.ToString();
        }
    }
}
