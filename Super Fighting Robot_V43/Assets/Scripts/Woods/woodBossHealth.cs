using UnityEngine;
using System.Collections;

public class woodBossHealth : MonoBehaviour {

    private float currentBossHealth, updatedBossHealth;
    private CheckPlayerInRange range;
    private fireBossFight bossFight;
    private EnemyHealthMid health;
    private HealthManager playerlife;
    private Animator anim;
    private bool Shoot = false;

    // Use this for initialization
    void Start()
    {
        bossFight = FindObjectOfType<fireBossFight>();
        health = GetComponent<EnemyHealthMid>();
        currentBossHealth = GetComponent<EnemyHealthMid>().enemyHealth;
        updatedBossHealth = currentBossHealth;
        range = FindObjectOfType<CheckPlayerInRange>();
        playerlife = FindObjectOfType<HealthManager>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        healthCheck();
        if (playerlife.isDead == true)
        {
            health.enemyHealth = 60;
       
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
