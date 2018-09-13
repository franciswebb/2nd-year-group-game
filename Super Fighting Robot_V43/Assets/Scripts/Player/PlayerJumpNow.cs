using UnityEngine;
using System.Collections;

public class PlayerJumpNow : MonoBehaviour
{
    public float timeHeld = 0.0f;
    private bool bigJump = true;
    private Player player;
    public float timeToFull = 0.5f, maxJumpHeight = 14, minJumpHeight = 4;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
      
        if (Input.GetButton("Jump"))
        {
            timeHeld += Time.deltaTime;
            if (timeHeld < 0.5f && bigJump == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * maxJumpHeight);


                /*
                if (player.playerRight)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
                }

                if (player.playerRight==false)
                {

                }
                */


            }
            else
            {
                bigJump = false;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            timeHeld = 0f;
            if (player.canDoubleJump)
            {
                timeHeld += Time.deltaTime;
                player.secondJumpSFX.Play();
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, minJumpHeight);
                bigJump = true;
           
            }

        }

        if (Input.GetButtonUp("Jump"))
        {
            bigJump = false;
        }

    }


}

