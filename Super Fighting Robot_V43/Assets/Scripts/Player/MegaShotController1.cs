using UnityEngine;
using System.Collections;

public class MegaShotController1 : MonoBehaviour
{

    private Rigidbody2D ribo2d;

    public float speed;

    public bool canShoot;
    public Player player;

    public int bullet_GunTypeSwitch = 0;

    public int damageToGive, explodeDelay;

    private float flyerLocation2, playerLocation2, checkerOfTheDistance;
    // Use this for initialization
    void Start()
    {
        ribo2d = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<Player>();

        playerLocation2 = player.transform.position.x;
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            damageToGive = 100; // dont work as a public var is over written by inspector
        }


        ribo2d.velocity = new Vector2(speed, ribo2d.velocity.y);



        GameObject[] shotsToFind = GameObject.FindGameObjectsWithTag("Bullets");

        int shotCount = shotsToFind.Length;

        Debug.Log(shotCount);

        if (shotCount == 4)
        {
            Destroy(GameObject.Find("MegaShot(Clone)"));
            //Destroy(gameObject);
        }




    }

    void CheckWeaponType()
    {
        switch (bullet_GunTypeSwitch)
        {
            case 0:             //                  get standing shootpos

                //shooting

                Debug.Log("THIS IS DEFAULT = LEMONS");
                break;


            case 1:


                Debug.Log("THIS IS 1 LEAF BLADE!");

                break;


            case 2:

                Debug.Log("FLAME GUN!");
                break;


            case 3:

                Debug.Log("WATER!");
                break;

            default:
                Debug.Log("Default case");
                break;

        }

    }// END CHECK WEAPON TYPE



    void OnTriggerEnter2D(Collider2D other)  // FIX
    // other here is a variable that is then used in the if statements
    {

        if (other.tag == "Bullets")
        {
            return;
        }

        if (other.tag == "Block")
        {
            Destroy(this.gameObject);
            //            Destroy(gameObject);

        }




        if (other.tag == "Player")
        {

            player.damageToGive = damageToGive;
            player.Damage_Invins();

        }





    } // END on trigger
}
