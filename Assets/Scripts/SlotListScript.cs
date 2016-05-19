using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotListScript : MonoBehaviour {

    

    void Start()
    {
       
    }

    public void addItemToNextFreeSlot(Item _item, Transform itemTest) {

        GameObject variableForPrefab = (GameObject)Resources.Load("Prefabs/ItemTest");
        GameObject asd = Instantiate(variableForPrefab);        
        asd.transform.GetComponent<ItemOnObject>().setItem(_item);


        for (int i = 0; i < transform.childCount; i++) {

            if (transform.GetChild(i).childCount == 0) {
                asd.transform.parent = transform.GetChild(i);
                break;
            }
            
        }
    }
}
