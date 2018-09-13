using UnityEngine;
using System.Collections;

public class EnemyHealthMid : MonoBehaviour
{

    public int enemyHealth;

    public GameObject deathEffect;

    public float moveSpeed;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    private PickUpBaddieManager pickup;
    private Rigidbody2D enemyRibo2d;
    private EnemyPatrol enemyPatrolScript;

    // Use this for initialization
    void Start()
    {
        enemyRibo2d = gameObject.GetComponent<Rigidbody2D>();
        enemyPatrolScript = gameObject.GetComponent<EnemyPatrol>();
        pickup = FindObjectOfType<PickUpBaddieManager>();
    }

    // Update is called once per frame
    void Update()
    {



        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            pickup.PickUpManagement();
        }

    }

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;

    }

    public void KnockBackEnemy()
    {
     //   enemyPatrolScript.enabled = false;
        knockbackCount = knockbackLength;
        if (knockbackCount <= 0)
        {
            if (enemyRibo2d.velocity.x > moveSpeed)
            {
                enemyRibo2d.velocity = new Vector2(moveSpeed, enemyRibo2d.velocity.y);
            }

            if (enemyRibo2d.velocity.x < -moveSpeed)
            {
                enemyRibo2d.velocity = new Vector2(-moveSpeed, enemyRibo2d.velocity.y);
            }
        }
        else
        {
            if (knockFromRight)
                enemyRibo2d.velocity = new Vector2(-knockback, knockback);
            StartCoroutine("ResetDelay");

            if (!knockFromRight)
                enemyRibo2d.velocity = new Vector2(knockback, knockback);
            StartCoroutine("ResetDelay");


            knockbackCount -= Time.deltaTime;
        }

    }


    public IEnumerator ResetDelay()
    {

        Debug.Log("CORUTINE STARTED");
        yield return new WaitForSeconds(2);
        enemyPatrolScript.enabled = true;
    }



}
