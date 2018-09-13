using UnityEngine;
using System.Collections;

public class TUTBoss : MonoBehaviour
{
    //   public AudioClip victoryMusic;
    public GameObject laBossManager;

    //  Random rnd = new Random();

    public int randoInt = 0, min = 0, max = 3;
    private float randoFloat = 0, minfloat = 2, maxfloat = 4.5f;
    public bool shoot, lowShot, hasJumped, playerInBossRoom = false, isDeed = false;

    private float bossLastStage = 17.5f;
    //public float 

    // public EnemyHealthMid bossHealthScript;
    private float currentBossHealth, updatedBossHealth;



    private AudioManager theAM;



    public Transform ballSpawnPoint, ballSpawnPlat;
    public GameObject ballShot, ballShootPlat;

    #region Animator
    private Animator anim;
    #endregion

    // Use this for initialization
    void Start()
    {
        currentBossHealth = GetComponent<EnemyHealthMid>().enemyHealth;
        theAM = FindObjectOfType<AudioManager>();




        //     less than the other when equal to back to 0
        //      currentBossHealth = bossHealthScript.enemyHealth;
        updatedBossHealth = currentBossHealth;


        anim = gameObject.GetComponent<Animator>();

        #region Picks Rando from min - max then +1 as to allow for max 
        // 
        /* 
         */
        randoInt = Random.Range(min, max);
        randoInt++;

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Shoot", shoot);
        anim.SetBool("Low", lowShot);
        anim.SetFloat("Health", currentBossHealth);







        if (Input.GetKeyDown(KeyCode.K))
        {
            if (playerInBossRoom)
            {
                GetComponent<EnemyHealthMid>().enemyHealth = 0;
            }
        }



        healthCheck();




    }




    void healthCheck()
    {
        //GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        currentBossHealth = GetComponent<EnemyHealthMid>().enemyHealth;

        if (currentBossHealth < updatedBossHealth)
        {
            StartCoroutine("IBeenShot");
        }

        if (currentBossHealth == updatedBossHealth)
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);


        if (currentBossHealth <= bossLastStage)
        {
            anim.speed = 2;
            theAM.GetComponent<AudioSource>().pitch = 1.07f;
            //  theAM.GetComponents<AudioSource>().audio.pitch = 1.07;
        }

        if (currentBossHealth == 0 || (currentBossHealth < 0))
        {
            laBossManager.GetComponent<BossManagmentScript>().isBeat = true;
            //       theAM.ChangeBGM(victoryMusic);
        }

    }








    public IEnumerator IBeenShot()
    {

        GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.15f);
        updatedBossHealth = currentBossHealth;


    }



    void HasJumpedCheck()
    {
        hasJumped = true;

    }




    void SpawnThing()
    {


        switch (randoInt)
        {
            case 1:

                Instantiate(ballShot, ballSpawnPoint.position, ballSpawnPoint.rotation);
                break;
            case 2:
                Instantiate(ballShot, ballSpawnPoint.position, ballSpawnPoint.rotation);

                break;
            case 3:
                Instantiate(ballShootPlat, ballSpawnPlat.position, ballSpawnPlat.rotation);

                break;
            default:
                break;
        }

        shoot = false;

    }

    void RandoWaitTime()
    {
        if (playerInBossRoom)
        {


            randoFloat = Random.Range(min, max);
            randoFloat++;

            StartCoroutine("hitDelayCo");
        }
    }



    public IEnumerator hitDelayCo()
    {

        yield return new WaitForSeconds(randoFloat);
        randoInt = Random.Range(min, max);
        randoInt++;
        //randoInt = 3;
        shoot = true;

        if (randoInt == 1)
        {
            lowShot = true;
        }
        if (randoInt == 2)
        {
            lowShot = true;
        }
        if (randoInt == 3)
        {
            lowShot = false;
        }


    }






}
