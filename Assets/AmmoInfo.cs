using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class AmmoInfo : MonoBehaviour {

    public void setAmmoInfoLoaded(int Loaded) {
        transform.GetChild(0).GetComponent<Text>().text = Loaded.ToString();

       // ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.test(1,2));

    }

    public void setAmmoInfoStock(int stock) {
        transform.GetChild(1).GetComponent<Text>().text = stock.ToString();
    }
}
