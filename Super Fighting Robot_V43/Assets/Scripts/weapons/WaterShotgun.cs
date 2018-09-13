using UnityEngine;
using System.Collections;

public class WaterShotgun : MonoBehaviour {
    private Rigidbody2D ribo2d;
   

    public float speed;
    public float walkDelay;
    public int damageToGive;
    public GameObject player;

    private EnemyHealthMid enemyHealthScript;
    private Rigidbody2D enemyRb2d;

    private MegaCloud cloud;
    // Use this for initialization
    void Start () {
        ribo2d = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        cloud = FindObjectOfType<MegaCloud>();
        enemyHealthScript = FindObjectOfType<EnemyHealthMid>();
        enemyRb2d = GetComponent<Rigidbody2D>();

        if (cloud.inWoodLevel)
        {
            damageToGive = damageToGive / 2;
        }
        if (cloud.inFireLevel)
        {
            damageToGive = damageToGive * 2;
        }

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        ribo2d.velocity = new Vector2(speed, ribo2d.velocity.y);

        GameObject[] shotsToFind = GameObject.FindGameObjectsWithTag("Bullets");

        int shotCount = shotsToFind.Length;

       // Debug.Log(shotCount);

        if (shotCount == 4)
        {
            Destroy(GameObject.Find("MegaShot(Clone)"));
            //Destroy(gameObject);
            Debug.Log("MEGASHOTSHOTCOUNT");
        }
        
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
        Debug.Log("SHOTGUN DESTROYED");
    }
    

    
        void OnTriggerEnter2D(Collider2D other)  // FIX
    // other here is a variable that is then used in the if statements
    {

        if (other.tag == "Bullets")
        {

        }

       /*if (other.tag == "Block")
        {
            //Debug.Log("BLOCK HIT");
           // Destroy(this.gameObject);
           
        }
        */



        if (other.tag == "Enemy") // DOESNT MATTER ABOUT y FIX
        {


         
            other.GetComponent<EnemyHealthMid>().giveDamage(damageToGive);
           
           
            if (other.transform.position.x < transform.position.x)
            {
                enemyHealthScript.knockFromRight = true;
            }
            else
            {
                enemyHealthScript.knockFromRight = false;
            }

            enemyHealthScript.KnockBackEnemy();
            
        
            Destroy(this.gameObject);
           
            
        }




    } // END on trigger

  
}
