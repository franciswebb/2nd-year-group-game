using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour
{

    private MegaCloud theCloud;
    private NewLevelSelectMoverControllerBetter newSwitchCounterScript;
    private Player player;

    public int newSwitchCounter;
    public bool canShoot = true;

    #region Level Select Locations 
    // /* */
    public GameObject LSLocFlame, LSLocWood, LSLocWater,
                      MMLockFlame, MMLockWood, MMLockWater,
                      BadManIcon, MM_BB_Loc, HidAll,
                      fireSprite, woodSprite, waterSprite;
    #endregion


    #region Level Select Locations 
    // /* */

    #endregion




    private string LevelToLoad_LS_MM;



    // Use this for initialization
    void Start()
    {
        newSwitchCounterScript = GetComponent<NewLevelSelectMoverControllerBetter>();
        player = FindObjectOfType<Player>();
        theCloud = FindObjectOfType<MegaCloud>();





        if (theCloud.fireFinished_Cloud && theCloud.waterFinished_Cloud && theCloud.woodFinished_Cloud)
            theCloud.finalUnlocked_Cloud = true;

        CheckFinalUnlockedNormalMeans();
    }

    // Update is called once per frame
    void Update()
    {
        //  CheckToBlockLevel();
        newSwitchCounter = newSwitchCounterScript.counter;

        CheckFinalUnlockedNormalMeans();
        switchTryTwo();
    }

    void CheckFinalUnlockedNormalMeans()
    {
        if (theCloud.fireFinished_Cloud && theCloud.waterFinished_Cloud && theCloud.woodFinished_Cloud)
            theCloud.finalUnlocked_Cloud = true;

    }


    void switchTryTwo()
    {
        if (theCloud.finalUnlocked_Cloud)
        {
            #region Move things about Final Pos 
            GameObject.Find("BAD MAN").transform.position = BadManIcon.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("MegaLevel Selecter").transform.position = MM_BB_Loc.transform.position;      //   other method didnt work till i did this way then tested with out and yea

            GameObject.Find("FLAME MAN").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("Wood Man").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            GameObject.Find("Water Man").transform.position = HidAll.transform.position;      //   other method didnt work till i did this way then tested with out and yea
            #endregion



            #region if hasnt beat will load level 
            // /* */

            if (canShoot)
            {
                if (Input.GetButtonDown("MegaBuster"))
                {
                    theCloud.inFinalLevel = true;

                    LevelToLoad_LS_MM = "8 Final Level";

                    Application.LoadLevelAsync(LevelToLoad_LS_MM);
                }
            }
            #endregion

        }
        else
        {

            switch (newSwitchCounter)
            {
                #region FIRE Level 
                // /* */

                case 1:
                    #region Move things about Fire Pos 
                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockFlame.transform.position;      //   other method didnt work till i did this way then tested with out and yea

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = false;
                    #endregion

                    #region Check if the players beat this level already 
                    // /* */

                    if (theCloud.fireFinished_Cloud)
                    {
                        canShoot = false;
                        GameObject.Find("LevelSprite FireM").GetComponent<SpriteRenderer>().enabled = false;

                    }
                    else
                    {
                        canShoot = true;
                        GameObject.Find("LevelSprite FireM").GetComponent<SpriteRenderer>().enabled = true;

                    }
                    #endregion

                    #region if hasnt beat will load level 
                    // /* */

                    if (canShoot)
                    {
                        if (Input.GetButtonDown("MegaBuster"))
                        {
                            theCloud.inFireLevel = true;

                            LevelToLoad_LS_MM = "6 Fire";

                            Application.LoadLevelAsync(LevelToLoad_LS_MM);
                        }
                    }
                    #endregion


                    break;
                #endregion

                #region Wood Level 
                // /* */

                case 2:

                    #region Move things about Wood Pos 
                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockWood.transform.position;

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = false;
                    #endregion

                    #region Check if the players beat this level already 
                    // /* */

                    if (theCloud.woodFinished_Cloud)
                    {
                        canShoot = false;
                        GameObject.Find("LevelSprite WdM").GetComponent<SpriteRenderer>().enabled = false;

                    }
                    else
                    {
                        canShoot = true;
                        GameObject.Find("LevelSprite WdM").GetComponent<SpriteRenderer>().enabled = true;

                    }
                    #endregion

                    #region if hasnt beat will load level 
                    // /* */

                    if (canShoot)
                    {
                        if (Input.GetButtonDown("MegaBuster"))
                        {
                            theCloud.inWoodLevel = true;

                            LevelToLoad_LS_MM = "5 Wood";

                            Application.LoadLevelAsync(LevelToLoad_LS_MM);
                        }
                    }
                    #endregion

                    break;
                #endregion

                #region Water Level 
                // /* */

                case 3:

                    #region Move things about Water Pos 
                    GameObject.Find("MegaLevel Selecter").transform.position = MMLockWater.transform.position;

                    GameObject.Find("Level select animation FM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WdM").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Level select animation WtrM").GetComponent<SpriteRenderer>().enabled = true;
                    #endregion


                    #region Check if players beat this level already 
                    // /* */

                    if (theCloud.waterFinished_Cloud)
                    {
                        canShoot = false;
                        GameObject.Find("LevelSprite WtrM").GetComponent<SpriteRenderer>().enabled = false;

                    }
                    else
                    {
                        canShoot = true;
                        GameObject.Find("LevelSprite WtrM").GetComponent<SpriteRenderer>().enabled = true;
                    }
                    #endregion

                    #region if hasnt beat will load level 
                    // /* */

                    if (canShoot)
                    {
                        if (Input.GetButtonDown("MegaBuster"))
                        {
                            theCloud.inWaterLevel = true;

                            LevelToLoad_LS_MM = "4 Water";

                            Application.LoadLevelAsync(LevelToLoad_LS_MM);
                        }
                    }
                    #endregion


                    break;
                #endregion

                default:
                    break;

            }
            GameObject.Find("BAD MAN").transform.position = HidAll.transform.position;      //    This Hides the final bad level if the final isnt unlocked

        }




    }


    void CheckToBlockLevel()
    {
        /*
        if (theCloud.finalUnlocked_Cloud == false)
        {

            if (theCloud.fireFinished_Cloud == true)
            {

                if (newSwitchCounter == 1)
                {
                    canShoot = true;
                }
                //fire finished hid visability
            }
            else
            {
                if (newSwitchCounter == 1)
                {
                    canShoot = false;
                }
                // fire not visible do nothing
            }


            if (theCloud.woodFinished_Cloud)
            {

                if (newSwitchCounter == 2)
                {
                    canShoot = true;
                }
                //wood finished hid visability
            }
            else
            {
                if (newSwitchCounter == 2)
                {
                    canShoot = false;
                }
                // wood not visible do nothing
            }


            if (theCloud.waterFinished_Cloud)
            {

                if (newSwitchCounter == 3)
                {
                    canShoot = true;
                }
                //water finished hid visability
            }
            else
            {
                if (newSwitchCounter == 3)
                {
                    canShoot = false;
                }
                // water not visible do nothing
            }


        }
        else
        {
            canShoot = true;

        }




        */












    }





}
