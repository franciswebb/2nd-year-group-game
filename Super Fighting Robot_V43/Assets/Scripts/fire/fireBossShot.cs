using UnityEngine;
using System.Collections;

public class fireBossShot : MonoBehaviour
{

	private Rigidbody2D ribo2d;

    public float speed;

    public bool canShoot;
    public GameObject player, explodeShot;
    public Transform explodePoint;
    private Player Person;
    

    private float flyerLocation2, playerLocation2, checkerOfTheDistance;

    // Use this for initialization
    void Start()
    {

        ribo2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        Person = FindObjectOfType<Player>();
      
        

        playerLocation2 = Person.transform.position.x;
        flyerLocation2 = gameObject.transform.position.x;

        checkerOfTheDistance = flyerLocation2 - playerLocation2;
        if (checkerOfTheDistance > 0)
        {
            
            speed = -speed;
            
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
       
    }

    // Update is called once per frame
    void Update()
    {

           

        ribo2d.velocity = new Vector2(speed, ribo2d.velocity.y);


      
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
            Instantiate(explodeShot, explodePoint.position, explodePoint.rotation);
            
            //            Destroy(gameObject);

        }




        if (other.tag == "Player") // DOESNT MATTER ABOUT y FIX
        {
            //    Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(explodeShot, explodePoint.position, explodePoint.rotation);

        }




    } // END on trigger
}
