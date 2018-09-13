using UnityEngine;
using System.Collections;

public class LargeWhaleManager : MonoBehaviour
{

    public float playerRange;
    public float minTime, maxTime;
  
    private float updatedEnemyHealth, currentEnemyHealth;
   

    
    public GameObject enemyShot;
    public Player player;
    public HealthManager healthManager;
    private EnemyHealthMid enemyHealthScript;


    private float waitBetweenShots;
    private float shotCounter;

    public Transform launchPoint;

    // Use this for initialization
    void Start()
    {
        currentEnemyHealth = GetComponent<EnemyHealthMid>().enemyHealth;
        player = FindObjectOfType<Player>();

        shotCounter = waitBetweenShots;
        updatedEnemyHealth = currentEnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        shotCounter -= Time.deltaTime;

        if (player.transform.position.x < transform.position.x && shotCounter < 0 && healthManager.GetPlayerHealth() < 100)
        {
            Instantiate(enemyShot, launchPoint.position, launchPoint.rotation);
            waitBetweenShots = Random.Range(minTime, maxTime);

            shotCounter = waitBetweenShots;
        }
    }

    void HealthCheck()
    {
        if (currentEnemyHealth < updatedEnemyHealth)
        {
           
            StartCoroutine("BeenShot");
            Debug.Log("WILLY BEEN HIT");
        }
        if (currentEnemyHealth == updatedEnemyHealth)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
    public IEnumerator BeenShot()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0, 1f);
        Debug.Log("WHALE COLOUR CHANGE");
        yield return new WaitForSeconds(0.15f);
        updatedEnemyHealth = currentEnemyHealth;
    }












}






