using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    private Player player;

    public string startLevel, levelSelect,skipLevel;

    private int levelsCompleted = 0;


    private bool finalUnlockedPP = false, tutsFinishedPP = false, fireDonePP = false, 
                 waterDonePP = false, woodDonePP = false;

    private MegaCloud cloud;


    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<Player>();
        cloud = FindObjectOfType<MegaCloud>();
        player.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void NewGame()
    {
        player.enabled = true;
        PlayerPrefs.SetInt("LevelsCurrentlyCompleted", levelsCompleted);



        /*
             private bool finalUnlockedPP = false, tutsFinishedPP = false, fireDonePP = false, 
                 waterDonePP = false, woodDonePP = false;

         */

        PlayerPrefs.SetString("Final Unlocked", "");
        PlayerPrefs.SetString("Tut Finished", "");
        PlayerPrefs.SetString("Fire Finished", "");
        PlayerPrefs.SetString("Water Finished", "");
        PlayerPrefs.SetString("Wood Finished", "");


        Application.LoadLevel(startLevel);

        cloud.inTutLevel = true;
    }

    public void LevelSelect()
    {

        Application.LoadLevel(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SkipToFinal()
    {

        cloud.finalUnlocked_Cloud=true;
        cloud.fireFinished_Cloud = true;
        cloud.waterFinished_Cloud = true;
        cloud.woodFinished_Cloud = true;

        Application.LoadLevel(levelSelect);
    }
    


}// END ALL