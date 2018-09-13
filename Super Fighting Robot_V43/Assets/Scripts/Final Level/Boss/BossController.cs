using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    private Transform startTransform;

    private float moveSpeed1 = 4.5f, moveSpeed2 = 8;
    private float randFloat, randFloatMin = 1, randFloatMax = 2;
    private bool stage2 = false;

    public GameObject badMegaShot, fireShotPrefab, waterShotPrefab;
    public Transform shotPos;

    private BossPatrolMan patrolScript;

    public int randoInt = 0, min = 0, max = 3;

    private Animator anim;

    private NewPlayerInBossRoom playerIn;
    private bool startFight;


    private CheckPlayerInRange playerInRange;

    private EnemyHealthMid bossHealth;

    private MegaCloud cloud;

    // Use this for initialization
    void Start()
    {
        cloud = FindObjectOfType<MegaCloud>();
        startTransform = transform;

        patrolScript = GetComponentInChildren<BossPatrolMan>();

        playerIn = FindObjectOfType<NewPlayerInBossRoom>();

        anim = GetComponentInChildren<Animator>();

        playerInRange = GetComponent<CheckPlayerInRange>();

        bossHealth = GetComponentInChildren<EnemyHealthMid>();


        randoInt = Random.Range(min, max);
        randoInt++;

        if (startFight == true)
        {

            patrolScript.canWalk = true;


        }
        StartCoroutine("ShotDelay");



    }

    // Update is called once per frame
    void Update()
    {
        startFight = playerIn.playerHasEntered;
        anim.SetBool("Start", startFight);
        anim.SetBool("Stage 2", stage2);





        if (startFight == true)
        {

            patrolScript.canWalk = true;


        }
        if (startFight != true)
        {
            patrolScript.canWalk = false;

        }


        if (playerIn.playerHasEntered)
        {
            startFight = true;
        }
        else
        {
            startFight = false;

        }



        if (bossHealth.enemyHealth <= 25)
        {
            stage2 = true;
            patrolScript.moveSpeed = 8;
        }


        if (bossHealth.enemyHealth <= 0)
        {
            victory();
        }



    }






    public IEnumerator ShotDelay()
    {
        randFloat = Random.Range(randFloatMin, randFloatMax);
        randFloat++;
        if (stage2 != true)
        {
            randFloatMin = 2;
            randFloatMax = 4;
        }
        else
        {
            randFloatMin = 0;
            randFloatMax = 2;
        }


        yield return new WaitForSeconds(randFloat);

        // randoInt = 2;         //Test to find out 
        PewPew();
        StartCoroutine("ShotDelay");
    }

    void PewPew()
    {
        switch (randoInt)
        {

            case 1:
                // speed = -speed if player to the right

                Instantiate(badMegaShot, shotPos.position, shotPos.rotation);



                break;

            case 2:
                fireShotPrefab.GetComponent<fireBossShot>().speed = 5;
                Instantiate(fireShotPrefab, shotPos.position, shotPos.rotation);

                break;

            case 3:
                Instantiate(waterShotPrefab, shotPos.position, shotPos.rotation);
                break;







            default:
                randoInt = Random.Range(min, max);
                randoInt++;
                break;

        }
        randoInt = Random.Range(min, max);
        randoInt++;

    }



    void victory()
    {
        Debug.Log("DDDDDDDDDDDDOOOOOOOOOOOOOOOOOOONNNNNNNNNNNNNNNNNNNNEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        Application.LoadLevelAsync("11 Credits");

        cloud.inFinalLevel = false;
    }






}
