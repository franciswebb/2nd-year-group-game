using UnityEngine;
using System.Collections;

public class BossEnemyHealth : MonoBehaviour
{

    public int enemyHealth = 100;

    public GameObject deathEffect;
    private PickUpBaddieManager PickUpManageScript;
    private LevelLoaderCloudCheck loadLevelObject;

    // Use this for initialization
    void Start()
    {
        PickUpManageScript = GetComponent<PickUpBaddieManager>();
        loadLevelObject = FindObjectOfType<LevelLoaderCloudCheck>();
    }

    // Update is called once per frame
    void Update()
    {



        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            PickUpManageScript.PickUpManagement();
            loadLevelObject.LoadLevel();
            Destroy(gameObject);

        }

    }

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }

}
