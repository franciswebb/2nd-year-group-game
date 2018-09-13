using UnityEngine;
using System.Collections;

public class SmallWalkingDudeSpeedyControl : MonoBehaviour
{
    private EnemyPatrol enemyPatrolScript;
    private CheckPlayerInRange inRangeScript;
    private EnemyHealthMid HealthScript;
    private Animator anim;
    private float moveSpeedStart;
    private int enemyHealthStart, enemyHealthBuff;
    private bool doOnce;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        inRangeScript = GetComponent<CheckPlayerInRange>();
        enemyPatrolScript = GetComponent<EnemyPatrol>();
        moveSpeedStart = enemyPatrolScript.moveSpeed;
        HealthScript = GetComponent<EnemyHealthMid>();
        enemyHealthStart = HealthScript.enemyHealth;
        enemyHealthBuff = enemyHealthStart + enemyHealthStart;

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("In Range", inRangeScript.playerInRange);


        if (inRangeScript.playerInRange)
        {
            //       enemyPatrolScript.moveSpeed = enemyPatrolScript.moveSpeed * 2;
            //GetComponent<SpriteRenderer>().color = new Color(redColour[0], redColour[1], redColour[2], redColour[3]);
            enemyPatrolScript.moveSpeed = 7;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            /*
            if (doOnce)
            {
                HealthScript.enemyHealth = 4;
                doOnce = true;
            }
            */
            //HealthScript.enemyHealth = enemyHealthBuff;
        }
        else
        {
            doOnce = true;
            enemyPatrolScript.moveSpeed = moveSpeedStart;
            GetComponent<SpriteRenderer>().color = new Color(0.25f, 0.25f, 0.25f, 1);
            HealthScript.enemyHealth = enemyHealthStart;
        }

    }
}
