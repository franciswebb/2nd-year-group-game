using UnityEngine;
using System.Collections;

public class EnemyShotController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D ribo2d;
    public bool canShoot;
    private Player player;
    private HealthManager healthManager;
    public float hitDelay;
    public float invinsibleDelay;
    public float canHitDelay;

    public int damageToGive;

    // Use this for initialization
    void Start()
    {


        ribo2d = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<Player>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {


        ribo2d.velocity = new Vector2(speed, ribo2d.velocity.y);

    }




    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Block")
        {

            Destroy(this.gameObject);

        }

        if (other.tag == "Player")
        {
            if (other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }

            player.damageToGive = damageToGive;
            player.Damage_Invins();
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }

            player.damageToGive = damageToGive;
            player.Damage_Invins();
            Destroy(this.gameObject);
        }
    }
}