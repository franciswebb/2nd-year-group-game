using UnityEngine;
using System.Collections;

public class LevelLoaderCloudCheck : MonoBehaviour
{
    private MegaCloud cloud;
    private bool playerInEndZone;
    private bool inFire = false, inWood = false, inWater = false, inFinal = false;
    private AudioManager theAM;


    // Use this for initialization
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();


        cloud = FindObjectOfType<MegaCloud>();

        playerInEndZone = false;


        if (cloud.inFireLevel)
        {
            inFire = true;
        }
        if (cloud.inWoodLevel)
        {
            inWood = true;
        }
        if (cloud.inWaterLevel)
        {
            inWater = true;
        }
        if (cloud.inFinalLevel)
        {
            inFinal = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpLoad();


    }

    void UpLoad()
    {
        if (Input.GetAxisRaw("Climb") > 0 && playerInEndZone == true)
        {
            if (inFire)
            {
                cloud.inFireLevel = false;
                cloud.fireFinished_Cloud = true;
            }

            if (inWater)
            {
                cloud.inWaterLevel = false;
                cloud.waterFinished_Cloud = true;
            }

            if (inWood)
            {
                cloud.inWoodLevel = false;
                cloud.woodFinished_Cloud = true;
            }

            if (inFinal)
            {
                cloud.inFinalLevel = false;
            }

            Application.LoadLevelAsync("3 Level Select");


        }

    }

    public void LoadLevel()
    {
        if (inFire)
        {
            cloud.inFireLevel = false;
            cloud.fireFinished_Cloud = true;
        }

        if (inWater)
        {
            cloud.inWaterLevel = false;
            cloud.waterFinished_Cloud = true;
        }

        if (inWood)
        {
            cloud.inWoodLevel = false;
            cloud.woodFinished_Cloud = true;
        }

        if (inFinal)
        {
            cloud.inFinalLevel = false;
        }

        theAM.GetComponent<AudioSource>().loop = true;


        Application.LoadLevelAsync("3 Level Select");


    }


    #region Check If Player Overlaps

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInEndZone = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInEndZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInEndZone = false;
        }
    }

    #endregion

}
