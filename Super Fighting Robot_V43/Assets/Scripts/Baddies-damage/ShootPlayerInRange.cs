using UnityEngine;
using System.Collections;

public class ShootPlayerInRange : MonoBehaviour
{

    public float playerRange;

    public GameObject enemyShot;

    public Player player;

    private CheckPlayerInRange rangeCheck;

    public float waitBetweenShots;
    private float shotCounter;

    public Transform launchPoint;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        rangeCheck = FindObjectOfType<CheckPlayerInRange>();
        shotCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        shotCounter -= Time.deltaTime;

        if (player.transform.position.x < transform.position.x && shotCounter < 0 && rangeCheck.playerInRange == true)
        {
            Instantiate(enemyShot, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
        }
    }
}

