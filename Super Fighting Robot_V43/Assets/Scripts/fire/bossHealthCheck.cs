using UnityEngine;
using System.Collections;

public class bossHealthCheck : MonoBehaviour
{

    private float currentBossHealth, updatedBossHealth;
    private CheckPlayerInRange range;
    private fireBossFight bossFight;
    private EnemyHealthMid health;
    private HealthManager playerlife;

    // Use this for initialization
    void Start()
    {
        bossFight = FindObjectOfType<fireBossFight>();
        health = GetComponent<EnemyHealthMid>();
        currentBossHealth = GetComponent<EnemyHealthMid>().enemyHealth;
        updatedBossHealth = currentBossHealth;
        range = FindObjectOfType<CheckPlayerInRange>();
        playerlife = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthCheck();
        if (playerlife.isDead == true)
        {
            health.enemyHealth = 100;
            bossFight.firstFight = false;
            bossFight.firstFightFinished = false;
            bossFight.secondFight = false;
            bossFight.SecondFightFinished = false;

        }
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

    }








    public IEnumerator IBeenShot()
    {

        GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.15f);
        updatedBossHealth = currentBossHealth;


    }

}
