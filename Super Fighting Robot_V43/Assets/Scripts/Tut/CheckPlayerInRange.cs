using UnityEngine;
using System.Collections;

public class CheckPlayerInRange : MonoBehaviour
{
    private Player playPerson;


    public float distanceToPlayer = 11;

    private float thisObjectToCheck, playerLocation2;

    private float checkerOfTheDistance;
    public bool playerInRange = false, playerLeft;

    // Use this for initialization
    void Start()
    {
        playPerson = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        variableUpdateFunction();
        distanceFunction();

    }


    void variableUpdateFunction()
    {
        playerLocation2 = playPerson.transform.position.x;
        thisObjectToCheck = gameObject.transform.position.x;

        checkerOfTheDistance = thisObjectToCheck - playerLocation2;
    }


    void distanceFunction()
    {
        if (checkerOfTheDistance > 0)
        {
            //positive number means the player is to the left of flyer

            playerLeft = true;


            if (checkerOfTheDistance > distanceToPlayer)
                playerInRange = false; // player is outside of range


            if (checkerOfTheDistance <= distanceToPlayer)
                playerInRange = true; // player is close enough 


        }// END IF PLAYER TO THE LEFT



        if (checkerOfTheDistance < 0)
        {
            //negative number means the player is to the right of flyer
            playerLeft = false;

            if (checkerOfTheDistance > distanceToPlayer)
                playerInRange = false; // player is outside of range

            // move to the right and play dip
            checkerOfTheDistance = checkerOfTheDistance * -1; //turns it from a minus to positive to check
            if (checkerOfTheDistance > distanceToPlayer)
                playerInRange = false;

            if (checkerOfTheDistance <= distanceToPlayer)
                playerInRange = true;
        }




        if (playerInRange)
        {

        }
        else // Player Not in Range
        {

        }
    }






}
