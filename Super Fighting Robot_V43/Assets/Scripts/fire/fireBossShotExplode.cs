using UnityEngine;
using System.Collections;

public class fireBossShotExplode : MonoBehaviour {

    public int damageToGive, explodeDelay;

    private Player player;
    private HealthManager healthManager;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)  // FIX
    // other here is a variable that is then used in the if statements
    {

        if (other.tag == "Bullets")
        {
            StartCoroutine("explode");
        }
        else if (other.tag == "Player")
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

                StartCoroutine("explode");

            

        }
        else
        {
            StartCoroutine("explode");
        }
    } 


    public IEnumerator explode()
    {


        yield return new WaitForSeconds(explodeDelay);
        Destroy(this.gameObject);


    }

}
