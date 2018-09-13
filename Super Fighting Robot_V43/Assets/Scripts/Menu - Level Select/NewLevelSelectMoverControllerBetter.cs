using UnityEngine;
using System.Collections;

public class NewLevelSelectMoverControllerBetter : MonoBehaviour
{





    public bool moveMM = false, doOnce = true;
    public int counter = 1;





    // Use this for initialization
    void Start()
    {

        counter = 1;

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetAxisRaw("Climb") == 1)
        {

            if (!moveMM)
            {
                addTheMegaCounter();

                moveMM = true;
            }
        }

        if (Input.GetAxisRaw("Climb") == -1)
        {
            if (!moveMM)
            {
                subtractTheMegaCounter();

                moveMM = true;
            }

        }


        if (Input.GetAxis("Climb") > -0.99 || Input.GetAxis("Climb") < 0.99 || Input.GetAxis("Climb") == 0)
        {
            //          moveMM = false;
            // doOnce = true;

        }


        if (Input.GetAxisRaw("Climb") == 0)
        {
            doOnce = true;
            moveMM = false;

        }



        if (counter >= 4)
        {
            counter = 1;
        }

        if (counter <= 0)
        {
            counter = 3;
        }





    }// end update

    public void addTheMegaCounter()
    {

        if (doOnce == true)
        {
            counter++;

        }
        doOnce = false;

        moveTheMegaMan();
    }


    public void subtractTheMegaCounter()
    {
        if (doOnce == true)
        {
            counter--;
        }
        doOnce = false;
        moveTheMegaMan();
    }


    public void moveTheMegaMan()
    {
        if (moveMM == true)
        {
            switch (counter)
            {

                case 1:
                    // fire
                    break;
            }
            // Etc
        } //end if
    } // end function




}// end all
