using UnityEngine;
using System.Collections;

public class DamagePlayerOnContact : MonoBehaviour
{

    private Player player;

    public float canHitDelay = 4;
    private float invicTime = 4, numOfLoopsOfBlink = 4;
    public float hitDelay = 1;
    public int damageToGive = 20;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();

        invicTime = canHitDelay / numOfLoopsOfBlink; // this is making the blink set for one every loop
        invicTime = invicTime / 2;                   // this takes the setting for one loop halfs so for off and on


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.canhit == true)
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
            }

        }
    }
    /*  FIX HITTING PLAYER CONTINOUTSLLLLLLYYYYYYYY
     */
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.canhit == true)
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
            }

        }
    }
    
}

