using UnityEngine;
using System.Collections;

public class BossManagmentScript : MonoBehaviour
{
    public string levelTags;
    int levelChecker;
    private string levelToLoad = "3 Level Select";



   
    private bool playerMoveToMid = false;
    public GameObject BMSootMM;
    public Transform BMShoot;

    private LevelLoaderCloudCheck levelLoadering;



    private MegaCloud cloud;




    public AudioClip victoryMusic;
    private AudioManager theAM;


    public GameObject TutaBoss;
    private Player player;

    private float songLength;
    public bool isBeat = false;












    // Use this for initialization
    void Start()
    {


        player = FindObjectOfType<Player>();

        theAM = FindObjectOfType<AudioManager>();

        cloud = FindObjectOfType<MegaCloud>();

        levelLoadering = FindObjectOfType<LevelLoaderCloudCheck>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeat)
        {
            //      player.rb2dPlayer.velocity = new Vector2(1, player.rb2dPlayer.velocity.y);
            //      Debug.Log("ISDEEEDDEDEDEDEDEDEDEDED");


            //      player.GetComponent<Player>().cc.enabled=false; //.enabled = false;

            player.enabled = false;

            //    playerMoveToMid = true;
            StartCoroutine("Victory");

            //      DO BM AND CUTSCENE HERE
            //     player.enabled = true;




        }

    }




    public IEnumerator Victory()
    {
        cloud.inTutLevel = false;

        theAM.GetComponent<AudioSource>().pitch = 1f;
        theAM.GetComponent<AudioSource>().loop = false;
        theAM.ChangeBGM(victoryMusic);

        yield return new WaitForSeconds(8);
        levelLoadering.LoadLevel();

        // StartCoroutine("WaitTillAtMid");
        //        player.enabled = true;
        //LoadLevel();

    }

    void BossBeat()
    {
        //player.GetComponent<Animator>().enabled = true;
        if (playerMoveToMid)
        {

            Vector3 v = player.rb2dPlayer.velocity;
            v.x = 2.0f;
            player.rb2dPlayer.velocity = v;
        }

        StartCoroutine("WaitTillAtMid");

    }


    public IEnumerator WaitTillAtMid()
    {
        //    yield return new WaitForSeconds(4f);
        //    playerMoveToMid = false;
        //    Vector3 v = player.rb2dPlayer.velocity;
        //    v.x = 0.0f;
        //    player.rb2dPlayer.velocity = v;


        //  player.GetComponent<Player>().AnimeJump();
        yield return new WaitForSeconds(0.5f);
        //  player.rb2dPlayer.gravityScale = 0;
        //player.shootSFX.Play();



        //       FIX FROM HERE FOR CUTSCENE
        //     BMShoot = player.transform.position;
        //     BMShoot.x += 25;
        //     Instantiate(BMSootMM, BMShoot, BMSootMM.rotate);



    }


    public void LoadLevel()
    {
        cloud.tutFinished_Cloud = true;
        levelLoadering.LoadLevel();
        /*
                //Tuts
                PlayerPrefs.SetInt(levelTags, 1);


                levelChecker++;
                PlayerPrefs.SetInt("LevelsCurrentlyCompleted", levelChecker);

                Debug.Log("Level Loader - load next level (in box and climb pressed)");
                Application.LoadLevelAsync(levelToLoad);
                */

    }




}
