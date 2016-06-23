using UnityEngine;
using System.Collections;
using Assets.ITSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Assets.EventSystem;
using Assets.Scripts;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
    InputManager inputManager;
    [SerializeField]
    Transform equipmentPoint;
    [SerializeField]
    Transform headPoint;
    [SerializeField]
    Transform bodyPoint;

    private ItemHuman itemHuman;

    private ItemClothing Head;
    private ItemClothing Body;
    private ItemClothing Mod1;
    private ItemClothing Mod2;

    private ItemClothing[] CharacterSlots = new ItemClothing[3];

    void Start () {
        ItemDataBase itemDatabase = (ItemDataBase)Resources.Load("ItemDataBase");
        itemHuman = (ItemHuman)itemDatabase.getItemByName("Player").getCopy();

        
        EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshPlayInfo, new customEventData(itemHuman));
        EventManager.Instance.AddListener(EventIdentifier.onConsumePlayer,(customEventData) => { consume(customEventData.Item); });
    }

    private void consume(Item _item) {
        ItemConsumable itemConsumable = (ItemConsumable)_item;

        itemConsumable.Stack--;

        itemHuman.Health += itemConsumable.RestoreHealth;
        itemHuman.Armor += itemConsumable.RestoreArmor;
        itemHuman.Energy += itemConsumable.RestoreEnergy;
        itemHuman.Oxygen += itemConsumable.RestoreOxygen;

        EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshPlayInfo, new customEventData(itemHuman));
        EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshSlot, new customEventData());

        if (itemConsumable.Stack == 0) {
            Destroy(equipmentPoint.GetChild(0).gameObject);
        }
    }

	void Update () {

        if (Input.GetKeyDown(inputManager.Fire1))
        {
            if (equipmentPoint.childCount > 0) {
                equipmentPoint.GetChild(0).GetComponent<IUsable>().Action1();
            }   
        }
        if (Input.GetKeyDown(inputManager.Fire2))
        {
            if (equipmentPoint.childCount > 0)
            {
                equipmentPoint.GetChild(0).GetComponent<IUsable>().Action2();
            }
        }
        if (Input.GetKeyDown(inputManager.Reload))
        {
            if (transform.GetChild(0).childCount > 0)
            {
                transform.GetChild(0).GetChild(0).GetComponent<IUsable>().Reload();
            }
        } 
    }

    public void setEquipment(GameObject _gameobject) {
        if (equipmentPoint.childCount > 0) {
            Destroy(equipmentPoint.GetChild(0).gameObject);
        }


        _gameobject.transform.SetParent(equipmentPoint);
    }

    public void setEquipmentOnPoint(GameObject _gameobject) {
        if (equipmentPoint.childCount > 0) {
            Destroy(equipmentPoint.GetChild(0).gameObject);
        }

        _gameobject.transform.position = equipmentPoint.transform.position;
        _gameobject.transform.rotation = equipmentPoint.transform.rotation;
        _gameobject.transform.SetParent(equipmentPoint);
    }

    public void SetClothing(Item _item) {
        ItemClothing itemClothing = (ItemClothing)_item;

        GameObject go = Instantiate(itemClothing.Prefab);

        if (itemClothing.TypeClothing == TypeClothing.Head) {
            
            RemoveClothingFromHuman(Head);
            Head = itemClothing;
            addClothingToHuman(Head);

            go.transform.position = headPoint.position;
            go.transform.rotation = headPoint.rotation;
            go.transform.SetParent(headPoint);
        }
        if (itemClothing.TypeClothing == TypeClothing.Body) {

            RemoveClothingFromHuman(Body);
            Head = itemClothing;
            addClothingToHuman(Body);

            go.transform.position = bodyPoint.position;
            go.transform.rotation = bodyPoint.rotation;
            go.transform.SetParent(bodyPoint);
        }
        if (itemClothing.TypeClothing == TypeClothing.Mod1) {
            RemoveClothingFromHuman(Mod1);
            Head = itemClothing;
            addClothingToHuman(Mod1);
        }
        if (itemClothing.TypeClothing == TypeClothing.Mod2) {
            RemoveClothingFromHuman(Mod2);
            Head = itemClothing;
            addClothingToHuman(Mod2);
        }

        EventManager.Instance.TriggerEvent(EventIdentifier.onRefreshPlayInfo, new customEventData(itemHuman));
    }

    private void addClothingToHuman(ItemClothing itemClothing) {
        if (itemClothing != null) {
            itemHuman.MaxHealth += itemClothing.Health;
            itemHuman.MaxArmor += itemClothing.Armor;
            itemHuman.MaxEnergy += itemClothing.Energy;
            itemHuman.MaxOxygen += itemClothing.Oxygen;
        }     
    }

    private void RemoveClothingFromHuman(ItemClothing itemClothing) {
        if (itemClothing != null) {
            itemHuman.MaxHealth -= itemClothing.Health;
            itemHuman.MaxArmor -= itemClothing.Armor;
            itemHuman.MaxEnergy -= itemClothing.Energy;
            itemHuman.MaxOxygen -= itemClothing.Oxygen;
            itemClothing = null;
        }    
    }
}
