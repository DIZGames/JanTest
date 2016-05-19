using UnityEngine;
using System.Collections;

public class InventoryKeys : MonoBehaviour {

    [SerializeField]
    private GameObject Backpack;
    [SerializeField]
    private GameObject CharacterScreen;
    [SerializeField]
    private GameObject Storage;
    [SerializeField]
    private GameObject CraftSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(Backpack.activeSelf);
            if (Backpack.activeSelf)
            {
                Debug.Log("Enabled");
                Backpack.SetActive(false);

            }
            else
            {
                Debug.Log("Disabled");
                Backpack.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(Storage.activeSelf);
            if (Storage.activeSelf)
            {
                Debug.Log("Enabled");
                Storage.SetActive(false);

            }
            else
            {
                Debug.Log("Disabled");
                Storage.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(CharacterScreen.activeSelf);
            if (CharacterScreen.activeSelf)
            {
                Debug.Log("Enabled");
                CharacterScreen.SetActive(false);

            }
            else
            {
                Debug.Log("Disabled");
                CharacterScreen.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(CraftSystem.activeSelf);
            if (CraftSystem.activeSelf)
            {
                Debug.Log("Enabled");
                CraftSystem.SetActive(false);

            }
            else
            {
                Debug.Log("Disabled");
                CraftSystem.SetActive(true);
            }
        }
    }
}
