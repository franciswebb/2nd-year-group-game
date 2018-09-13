using UnityEngine;
using System.Collections;

public class SuperMarioBossManager : MonoBehaviour {

    public float speed;
    private Rigidbody2D ribo2D;

    public int damageToGive;
    public GameObject mario;
    private Player player;
    // Use this for initialization
    void Start () {
        ribo2D = GetComponent<Rigidbody2D>();

        mario = GameObject.FindGameObjectWithTag("Enemy");
        player = FindObjectOfType<Player>();

        if (mario.transform.localScale.x < 0)
        {
           transform.localScale = new Vector3(1, 1, 1);
        }
        
       
        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            if (mario.transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


        ribo2D.velocity = new Vector2(speed, ribo2D.velocity.y);

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
    void DestroyGameObject()
    {
        Destroy(gameObject);
        
    }
}


