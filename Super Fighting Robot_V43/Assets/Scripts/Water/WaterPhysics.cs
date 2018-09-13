using UnityEngine;
using System.Collections;

public class WaterPhysics : MonoBehaviour
{

    private Player player;
    public float extendJump;

    public bool isInWater = false;

    


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isInWater = true;
            
            player.rb2dPlayer.gravityScale = 0f;
            player.rb2dPlayer.drag = 0.8f;
            player.jumpHeight += extendJump;




        }




    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInWater = false;
            
            player.rb2dPlayer.gravityScale = 1f;
            player.rb2dPlayer.drag = 0;
            player.jumpHeight -= extendJump;

        }
    }
}
