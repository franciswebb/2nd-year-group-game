using UnityEngine;
using System.Collections;

public class FlyingBaddie : MonoBehaviour
{
    private Player playPerson;
    private Animator anim;

    private Rigidbody2D ribo2d;
    public float movementSpeed;



    public float distanceToPlayerFromDip = 5;

    private Vector2 flyerLocation, playerLocation, startParentFlyer, dipEndXAxis;
    private float flyerLocation2, playerLocation2, newTransformCheckerPos;
    public Transform parentFlyer;
    private float checkerOfTheDistance;
    private bool dipNow = false, dipEnd = false;
    public bool playerInRange = false, playerLeft;

    // Use this for initialization
    void Start()
    {

        ribo2d = GetComponent<Rigidbody2D>();


        playPerson = FindObjectOfType<Player>();

        //177.11 - 173.08
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log("CHEKING DIS TILL PLAYER AND FLYER" + checkerOfTheDistance);



        anim.SetBool("Player In Range", playerInRange);
        anim.SetBool("Player Left", playerLeft);
        anim.SetBool("Player Right", !playerLeft);
        anim.SetBool("Dip", dipNow);
        anim.SetBool("DipEnd", dipEnd);




        // playerLocation.x = playPerson.transform.position.x;
        //   flyerLocation.x = gameObject.transform.position.x;
        playerLocation2 = playPerson.transform.position.x;
        flyerLocation2 = gameObject.transform.position.x;

        checkerOfTheDistance = flyerLocation2 - playerLocation2;

        if (checkerOfTheDistance > 0)
        {
            //positive number means the player is to the left of flyer

            playerLeft = true;


            if (checkerOfTheDistance > distanceToPlayerFromDip)
                playerInRange = false;


            // move to the left and play dip

            if (checkerOfTheDistance <= distanceToPlayerFromDip)
                playerInRange = true; // player is close enough now dip
        }

        if (checkerOfTheDistance < 0)
        {
            //negative number means the player is to the right of flyer

            playerLeft = false;


            if (checkerOfTheDistance > distanceToPlayerFromDip)
                playerInRange = false;



            // move to the right and play dip
            checkerOfTheDistance = checkerOfTheDistance * -1; //turns it from a minus to positive to check
            if (checkerOfTheDistance > distanceToPlayerFromDip)
                playerInRange = false;

            if (checkerOfTheDistance <= distanceToPlayerFromDip)
                playerInRange = true;
        }




        if (playerInRange)
        {
//            startParentFlyer = parentFlyer.position;
//
  //          if (playerLeft)
    //        {
      //          if (parentFlyer.position.x == startParentFlyer.x)
        //        {
        //
          //      }
            //    else
              //  {
        //            if(parentFlyer.position.x < startParentFlyer.x)
          //          {
      //                  // we go left

    //                movementSpeed = -movementSpeed;

  //                  ribo2d.velocity = new Vector2(movementSpeed, ribo2d.velocity.y);

//                    }


//                }
                //
  //          }
//




            dipNow = true;
        }
        else // Player Not in Range
        {

            //       if (parentFlyer.position.x == startParentFlyer.x)
            //        {
            //
            //      }
            //    else
            //  {
            //    if (parentFlyer.position.x < startParentFlyer.x)
            //  {
            // we go Right


            //    ribo2d.velocity = new Vector2(movementSpeed, ribo2d.velocity.y);

            //}


            //  }



   //         dipEnd = false;

     //       dipNow = false;
        }




    }

    void DipOnEnd()
    {
  //      dipEnd = true;
    }
    void DipOnStart()
    {
    }




    void SetXAxisAtStartDip()
    {
   //     startParentFlyer = parentFlyer.position;



    }


    void SetXAxisAtEndDip()
    {
   //     dipEndXAxis.x = parentFlyer.position.x;

   //     if (playerLeft)
    //    {
    //        newTransformCheckerPos = startParentFlyer.x - dipEndXAxis.x;

            //      parentFlyer.position.x = startParentFlyer;
            //      dipEndXAxis = dipEndXAxis.x + checkerOfTheDistance;
      //  }

        if (!playerLeft)
        {
            // NEGATIVE HOLLOW NUMBERS IS TO THE RIGHT 
            //  *-1;

        }



    }








}
