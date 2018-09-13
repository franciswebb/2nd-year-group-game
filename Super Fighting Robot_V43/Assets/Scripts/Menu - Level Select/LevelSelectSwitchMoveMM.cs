using UnityEngine;
using System.Collections;

public class LevelSelectSwitchMoveMM : MonoBehaviour
{

    public int LevelCheck = 1;

    private Player player;

    public GameObject LSLocFlame, LSLocWood, LSLocWater,
                      MMLockFlame, MMLockWood, MMLockWater,
                      BadManIcon, MM_BB_Loc, HidAll;

    public bool finalUnlocked = false, tutsFinished = true, isAxisInUse = true;
    private bool canShoot = true;



    private string LevelToLoad_LS_MM;

    int levelChecker;

    public MegaCloud cloud;
    public NewLevelSelectMoverControllerBetter playerCounterScript;
    private NewLevelSelectMoverControllerBetter newCounter;
    public int levelCheckerNewScript;


    // public LevelLoader loadLevelVar_Script;


    // Use this for initialization
    void Start()
    {
     //   cloud = GetComponent<MegaCloud>();
        newCounter = GetComponent<NewLevelSelectMoverControllerBetter>();
        player = FindObjectOfType<Player>();
        playerCounterScript = GetComponent<NewLevelSelectMoverControllerBetter>();


        levelChecker = PlayerPrefs.GetInt("LevelsCurrentlyCompleted");
        levelChecker = 3;
        checkWhatLevels();

    }//end start

    void FixedUpdate()
    {
        SelectAxisDown();

        levelCheckerNewScript = playerCounterScript.counter;
        Debug.Log("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH " + levelCheckerNewScript);

        setVisability();

    }


    void setVisability()
    {
        if(cloud.fireFinished_Cloud == true)
        {

            if (levelCheckerNewScript == 0)
            {
                canShoot = true;
            }
            //fire finished hid visability
        }
        else
        {
            if (levelCheckerNewScript == 0)
            {
                canShoot = false;
            }
            // fire not visible do nothing
        }


        if (cloud.tutFinished_Cloud)
        {

            //tut finished hid visability
        }
        else
        {
            return;
            // tut not visible do nothing
        }


        if (cloud.waterFinished_Cloud)
        {

            //water finished hid visability
        }
        else
        {
            return;
            // water not visible do nothing
        }


        if (cloud.woodFinished_Cloud)
        {

            //wood finished hid visability
        }
        else
        {
            return;
            // wood not visible do nothing
        }







    }












    void newestCheckWithBoolsLevelCompleted()
    {

    }
















    void checkWhatLevels()
    {
        if (levelChecker == 8 || levelChecker > 8)
        {
            finalUnlocked = true;


            GameObject.Find("FLAME MAN").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("Wood Man").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("Water Man").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("BAD MAN").transform.position = BadManIcon.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("MegaLevel Selecter").transform.position = MM_BB_Loc.transform.position;      //   other method didnt work till i did this way then tested with out and yea

        }
        else
        {
            GameObject.Find("BAD MAN").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea

        }


    }











    // Update is called once per frame
    void Update()
    {
        Selecter2();
        Debug.Log(cloud.finalUnlocked_Cloud + " LEVEL Select Switch MoveMM");


        Debug.Log(levelChecker + " LEVEL Select Switch MoveMM");

    }//end update



    void Selecter2()
    {

        if (cloud.finalUnlocked_Cloud)
        {


            if (Input.GetButtonDown("MegaBuster"))
            {

                LevelToLoad_LS_MM = "7 Final";

                Application.LoadLevelAsync(LevelToLoad_LS_MM);
            }


        }
        else
        {


            switch (levelCheckerNewScript)//was level check
            {

                case 0:             //                  tuts



                    if (cloud.tutFinished_Cloud)
                    {
                        levelCheckerNewScript = 3;
                    }
                    else
                    {
                        // all other are done move and activate final

                    }


                    //LevelCheck++;
                    break;



                case 1:             //                  Flame

                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockFlame.transform.position;      //   other method didnt work till i did this way then tested with out and yea

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = false;

                    //Application.LoadLevelAsync("Fire");



                    //loadLevelVar_Script.levelToLoad = ("Fire");

                    if (Input.GetButtonDown("MegaBuster"))
                    {
                        if (canShoot)
                        {
                            LevelToLoad_LS_MM = "6 Fire";

                            Application.LoadLevelAsync(LevelToLoad_LS_MM);

                        }
                    }




                        break;


                case 2:             //                  Wood

                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockWood.transform.position;

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = false;

                    if (Input.GetButtonDown("MegaBuster"))
                    {
                        if (canShoot)
                        {
                            LevelToLoad_LS_MM = "5 Wood";

                            Application.LoadLevelAsync(LevelToLoad_LS_MM);

                        }


                    }

                    //loadLevelVar_Script.levelToLoad = ("Wood");
                    break;




                case 3:             //                  Water

                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockWater.transform.position;

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = true;


                    if (Input.GetButtonDown("MegaBuster"))
                    {
                        if (canShoot)
                        {
                            LevelToLoad_LS_MM = "4 Water";

                            Application.LoadLevelAsync(LevelToLoad_LS_MM);

                        }


                    }



                    break;


                case 4:             //                  Final

                    if (cloud.finalUnlocked_Cloud)
                    {
                        // all other are done move and activate final
                        Debug.Log("FINAL UNLOCKED");
                    }
                    else
                    {
                        levelCheckerNewScript = 1;
                    }






                    break;




                default:            //                  Other
                    break;




            }

        }




    }













    public IEnumerator Delay()
    {


        yield return new WaitForSeconds(1);


    }






    /*
    if (Input.GetAxis("Climb") > 0)
    {
        Debug.Log("UP");
        LevelCheck++;

    }



    if (Input.GetAxis("Climb") < 0)
    {
        Debug.Log("DOWN");

        LevelCheck--;

    }

    */

    void UpDownMoveMent()
    {














        if ((Input.GetButtonDown("LS_Up")))
        {
            Debug.Log("UP");
            LevelCheck++;

        }



        if ((Input.GetButtonDown("LS_Down")))
        {
            Debug.Log("DOWN");

            LevelCheck--;

        }


    }



    void SelectAxisDown()
    {
        if (Input.GetAxisRaw("Climb") < 0)
        {
            Debug.Log("PRESSED");
            if (isAxisInUse == false)
            {
                LevelCheck--;
                isAxisInUse = true;
            }// end if axis
        }// end axis raw not 0
        if (Input.GetAxisRaw("Climb") > 0)
        {

            if (isAxisInUse == false)
            {
                LevelCheck++;
                isAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            isAxisInUse = false;
        }

    }// end slect axis



    void Selecter()
    {

        if (finalUnlocked)
        {


            if (Input.GetButtonDown("MegaBuster"))
            {
                Debug.Log("SHOT");

                LevelToLoad_LS_MM = "7 Final";

                Application.LoadLevelAsync(LevelToLoad_LS_MM);
            }


        }
        else
        {


            switch (LevelCheck)
            {

                case 0:             //                  tuts



                    if (tutsFinished)
                    {
                        LevelCheck = 3;
                    }
                    else
                    {
                        // all other are done move and activate final

                    }


                    //LevelCheck++;
                    break;



                case 1:             //                  Flame

                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockFlame.transform.position;      //   other method didnt work till i did this way then tested with out and yea

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = false;

                    //Application.LoadLevelAsync("Fire");



                    //loadLevelVar_Script.levelToLoad = ("Fire");

                    if (Input.GetButtonDown("MegaBuster"))
                    {
                        Debug.Log("SHOT");



                        LevelToLoad_LS_MM = "6 Fire";


                        //player.shooting = true;                       For some reason no working

                        Application.LoadLevelAsync(LevelToLoad_LS_MM);


                        //loadLevelVar_Script.LoadLevel();
                    }

                    //player.transform.position = MMLockFlame.transform.position;

                    break;


                case 2:             //                  Wood

                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockWood.transform.position;

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = false;

                    if (Input.GetButtonDown("MegaBuster"))
                    {
                        Debug.Log("SHOT");

                        LevelToLoad_LS_MM = "5 Wood";

                        Application.LoadLevelAsync(LevelToLoad_LS_MM);
                    }

                    //loadLevelVar_Script.levelToLoad = ("Wood");
                    break;




                case 3:             //                  Water

                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockWater.transform.position;

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = true;

                    //loadLevelVar_Script.levelToLoad = ("Water");

                    if (Input.GetButtonDown("MegaBuster"))
                    {
                        Debug.Log("SHOT");

                        LevelToLoad_LS_MM = "4 Water";

                        Application.LoadLevelAsync(LevelToLoad_LS_MM);
                    }


                    break;


                case 4:             //                  Final

                    if (finalUnlocked)
                    {
                        // all other are done move and activate final

                    }
                    else
                    {
                        LevelCheck = 1;
                    }






                    break;




                default:            //                  Other
                    break;

            }

        }




    }



}
