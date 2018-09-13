using UnityEngine;
using System.Collections;

public class BossDoorParentController : MonoBehaviour
{
    private bool playerNotAtPos = false;
    public GameObject pointB;
    private Player player;


    public Renderer rend;





    private Vector3 posB, currentPos, checkAgainstB;

    //1.5



    // Use this for initialization
    void Start()
    {

        #region Turn off visability

        rend = GetComponent<Renderer>();

        #endregion

        player = FindObjectOfType<Player>();
        //    posB = new Vector3(272, -3, 0);

        posB = pointB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        currentPos = player.transform.position;
        checkAgainstB = currentPos;

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {




            currentPos = player.transform.position;
            checkAgainstB = currentPos;

            if (checkAgainstB.x < posB.x)
            {
                player.enabled = false;
                StartCoroutine("DoorDelay");


                //your on the left of the door
            }
            else
            {
                return;
                // your on the right do nothing
            }


            //   posB=currentPos
            //     posB = 



            //        player.transform.position.x = Vector2.MoveTowards(player.transform.position.x,posB.transform.position.x, 1f);
            //       transform.position = Vector2.Lerp(player.transform.position, posB, 1);


        }



    }




    IEnumerator DoorDelay()
    {
        player.rb2dPlayer.velocity = new Vector2(0, 0);
        player.rb2dPlayer.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);
        rend.enabled = false;
        yield return new WaitForSeconds(0.5f);
        player.transform.position = Vector3.Lerp(currentPos, posB, 6.28f * 0.05f * Time.time);          // MID ONE IS SPEED
        rend.enabled = true;
        player.rb2dPlayer.gravityScale = 1;


        player.enabled = true;


    }




    /*
    IEnumerator moveToA()
    {
        playerNotAtPos = true;
        while (playerNotAtPos)
        {
      //      player.position = Vector3.MoveTowards(player.position, ptA, speed);
            yield return null;
        }

        ///if here, we can assume we have made it to A
     //   playerNotAtPos = false;
     //   StartCoroutine("moveToB");
    }
    */











}
