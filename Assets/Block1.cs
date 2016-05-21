using UnityEngine;
using System.Collections;

public class Block1 : MonoBehaviour {

    [SerializeField]
    private Block block;

    private int hitpoints;

	// Use this for initialization
	void Start () {
        this.block = (Block)block.getCopy();
	}
	
	// Update is called once per frame
	void Update () {

        if (block.hitPoints <= 0) {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
	}


    void OnCollisionEnter2D(Collision2D collision2D)
    {
        block.hitPoints = block.hitPoints - collision2D.gameObject.GetComponent<RocketScript>().Ammo.impactValue;

        Destroy(collision2D.gameObject);
        Debug.Log("Kollision");


        //block.hitPoints - collision.gameObject.GetComponent<

    }


}
