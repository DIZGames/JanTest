using UnityEngine;
using System.Collections;

public class RayCastObjectDetection : MonoBehaviour {

    public float damage = 10;
    public LayerMask ToHit;
    public Transform Bullet;
    public float BulletSpeed;
    float timeToFire = 0;
    Transform FirePoint;

    // Use this for initialization
    void Start()
    {
        FirePoint = transform.FindChild("FirePoint");
        if (FirePoint == null)
        {
            Debug.LogError("No FirePoint");
        }
    }



    // Update is called once per frame
    void Update()
    {
        //Shoot();

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //    Vector2 firePointPosition = new Vector2(transform.position.x, transform.position.y);


        //    // Berechnet Vektor vom Spieler zur Maus
        //    Vector2 vectornew = mouseposition - firePointPosition;
        //    // Normalisiert den Vektor
        //    vectornew.Normalize();


        //    Transform t = GameObject.Instantiate(Bullet);
        //    t.position = transform.position;
        //    t.rotation = transform.rotation;
        //    t.gameObject.name = "Rocket";

        //    Debug.Log(mouseposition.x.ToString() + " " + mouseposition.y.ToString());

        //    t.gameObject.GetComponent<Rigidbody2D>().AddForce(vectornew * BulletSpeed * Time.deltaTime,ForceMode2D.Impulse);

        //}

        //if (Input.GetButtonDown("Fire2"))
        //{

        //    ItemList asd = (ItemList)Resources.Load("ItemDatabase");

        //    Debug.Log(asd.itemList[0].itemName);

        //  //  GameObject textObject = (GameObject)Instantiate(Resources.Load("DamageText"));
        //}

    }

    void Shoot()
    {
        Vector2 mouseposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(FirePoint.position.x, FirePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mouseposition - firePointPosition, 100, ToHit);

        Debug.DrawLine(firePointPosition, (mouseposition - firePointPosition) * 100, Color.green);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("we hit " + hit.collider.name);
        }
    }
}
