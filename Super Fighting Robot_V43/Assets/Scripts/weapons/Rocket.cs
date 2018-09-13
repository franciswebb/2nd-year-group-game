using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    private Rigidbody2D ribo2d;

    public float speed;

    public bool canShoot;
    public GameObject player, explodeRocket;
    public Transform explodePoint;

    // Use this for initialization
    void Start()
    {

        ribo2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {

        ribo2d.velocity = new Vector2(speed, ribo2d.velocity.y);



        GameObject[] shotsToFind = GameObject.FindGameObjectsWithTag("Bullets");

        int shotCount = shotsToFind.Length;


        if (shotCount == 4)
        {
            Destroy(GameObject.Find("MegaShot(Clone)"));
            //Destroy(gameObject);
        }




    }

   


    void OnTriggerEnter2D(Collider2D other)  // FIX
    // other here is a variable that is then used in the if statements
    {

        if (other.tag == "Bullets")
        {

        }

        if (other.tag == "Block")
        {
            Destroy(this.gameObject);
            Instantiate(explodeRocket, explodePoint.position, explodePoint.rotation);
            Destroy(this.gameObject);
            //            Destroy(gameObject);

        }




        if (other.tag == "Enemy") // DOESNT MATTER ABOUT y FIX
        {
            //    Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(explodeRocket, explodePoint.position, explodePoint.rotation);

        }




    } // END on trigger
}
