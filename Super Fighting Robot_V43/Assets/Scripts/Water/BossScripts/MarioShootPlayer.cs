using UnityEngine;
using System.Collections;

public class MarioShootPlayer: MonoBehaviour {

	public float playerRange;

    public GameObject enemyShot;

    public Player player;

    public HealthManager healthManager;

    public float waitBetweenShots;
    private float shotCounter;

    public Transform launchPoint;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();

        shotCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
       
        shotCounter -= Time.deltaTime;

        if (player.transform.position.x < transform.position.x && shotCounter < 0 && healthManager.GetPlayerHealth() < 100)
        {
           
            Instantiate(enemyShot, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
        }
        else if (player.transform.position.x > transform.position.x && shotCounter < 0 && healthManager.GetPlayerHealth() < 100)
            {
            
                Instantiate(enemyShot, launchPoint.position, launchPoint.rotation);
                shotCounter = waitBetweenShots;
            }
       
        
    }
}


