using UnityEngine;
using System.Collections;

public class WoodsBoss : MonoBehaviour
{
    //   public AudioClip victoryMusic;
    public GameObject laBossManager;

    //  Random rnd = new Random();

    public int randoInt = 0, min = 0, max = 3;
    private float randoFloat = 0, minfloat = 2, maxfloat = 4.5f;
    public bool shoot, mouthShot, hasJumped, playerInBossRoom = false, isDeed = false;

    private float bossLastStage = 17.5f;
    //public float 

    // public EnemyHealthMid bossHealthScript;
    private float currentBossHealth, updatedBossHealth;



    private AudioManager theAM;



    public Transform ballSpawnPoint;
    public GameObject ballShot;

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


        //  ballSpawnPoint.position.x = 254.28;// (254.28f, -64.38f, 0);



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


        if (playerInBossRoom == true)
        {
            shoot = true;
        }
        if (playerInBossRoom == false)
        {
            shoot = false;
        }


        mouthShot = shoot;
        anim.SetBool("Shoot", shoot);

        anim.SetFloat("Health", currentBossHealth);


        Debug.Log(randoInt + " IS THE RANDO INT");
        Debug.Log(randoFloat + " IS THE RANDO float");




        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<EnemyHealthMid>().enemyHealth = 0;
        }



        healthCheck();

        Debug.Log(currentBossHealth + "!!!!!!!!!!!!!!!!!!!!!!!!!!! THE THING !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");



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
        randoInt = Random.Range(min, max);
        randoInt++;

        if (mouthShot == true)
        {
            Instantiate(ballShot, ballSpawnPoint.position, ballSpawnPoint.rotation);
            Debug.Log("awsdasd");
        }
        else if (randoInt == 2)
        {
            Instantiate(ballShot, ballSpawnPoint.position, ballSpawnPoint.rotation);
            Debug.Log("awsd");
        }
        else
        {

        }


        shoot = false;

    }

    void RandoWaitTime()
    {
        if (playerInBossRoom)
        {


            randoFloat = Random.Range(min, max);
            randoFloat++;

            StartCoroutine("RandoInt");
        }
    }



    public IEnumerator RandoInt()
    {

        yield return new WaitForSeconds(randoFloat);

        //randoInt = 3;
        shoot = true;

        if (randoInt == 1)
        {
            mouthShot = true;
            Debug.Log("11111111111111111111111111111RANDO1111111111111111111111111111");
        }
        if (randoInt == 2)
        {
            mouthShot = true;

            Debug.Log("22222222222222222222222222222RANDO2222222222222222222222222222222222222");
        }
        if (randoInt == 3)
        {
            mouthShot = false;
            Debug.Log("3333333333333333333333333333333333RANDO33333333333333333333333333333333");
        }






    }
}



