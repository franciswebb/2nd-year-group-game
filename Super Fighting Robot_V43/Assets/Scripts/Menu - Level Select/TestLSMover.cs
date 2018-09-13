using UnityEngine;
using System.Collections;

public class TestLSMover : MonoBehaviour
{
    public bool moveMM = false;
    public int counter = 0;
    public float inputCounter = 0;
    private bool isStart = true, isFinished = false, isTurningIGuess = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        inputCounter = Input.GetAxisRaw("Climb");


        if (Input.GetAxisRaw("Climb") == 1)
        {
            if (moveMM == false)
            {

                addTheMegaCounter();
            }
                moveMM = true;

        }

        if (Input.GetAxisRaw("Climb") == -1)
        {
            if (moveMM == false)
            {

                subtractTheMegaCounter();
            }
                moveMM = true;
        }



        if (Input.GetAxisRaw("Climb") > -0.2 || Input.GetAxisRaw("Climb") < -0.2) // || Input.GetAxisRaw("Climb") == 0)
        {
            moveMM = false;
        }


    }

    void moveTheMegaMan()
    {
        if (moveMM == true)
        {

            switch (counter)
            {
                case 1:
                    // fire
                    break;
            }

        } //end if
    } // end function



    void addTheMegaCounter()
    {
        counter++;
        moveTheMegaMan();
    }



    void subtractTheMegaCounter()
    {
        counter--;
        moveTheMegaMan();
    }

}








