using UnityEngine;
using System.Collections;
using Assets.EventSystem;
using Assets.ITSystem;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    [SerializeField]
    private Transform Health;
    [SerializeField]
    private Transform Armor;
    [SerializeField]
    private Transform Energy;
    [SerializeField]
    private Transform Oxygen;
    [SerializeField]
    private Transform MaxHealth;
    [SerializeField]
    private Transform MaxArmor;
    [SerializeField]
    private Transform MaxEnergy;
    [SerializeField]
    private Transform MaxOxygen;

    void Start () {
        EventManager.Instance.AddListener(EventIdentifier.onRefreshPlayInfo,(customEventData) => { refreshUI(customEventData.Item); });
	}

    private void refreshUI(Item _item) {
        ItemHuman itemHuman = (ItemHuman)_item;

        Health.GetComponent<Text>().text = itemHuman.Health.ToString();
        Armor.GetComponent<Text>().text = itemHuman.Armor.ToString();
        Energy.GetComponent<Text>().text = itemHuman.Energy.ToString();
        Oxygen.GetComponent<Text>().text = itemHuman.Oxygen.ToString();
        MaxHealth.GetComponent<Text>().text = itemHuman.MaxHealth.ToString();
        MaxArmor.GetComponent<Text>().text = itemHuman.MaxArmor.ToString();
        MaxEnergy.GetComponent<Text>().text = itemHuman.MaxEnergy.ToString();
        MaxOxygen.GetComponent<Text>().text = itemHuman.MaxOxygen.ToString();

    }
}
