using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public Transform enemySpawnPoint;
    private CheckPlayerInRange rangeCheck;
    public bool DoOnce = true;
    public int SpawnWaitTime = 10;
    private CameraManager camer;
    public int area;
    // Use this for initialization
    void Start()
    {

        rangeCheck = GetComponent<CheckPlayerInRange>();
        rangeCheck.playerInRange = false;
        camer = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camer.currentArea == area && rangeCheck.playerInRange == true)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {

        if (DoOnce == true)
        {
            DoOnce = false;
            StartCoroutine("SpawnDelay");

        }
        else
        {

        }


    }

    public IEnumerator SpawnDelay()
    {

        Instantiate(enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
        yield return new WaitForSeconds(SpawnWaitTime);
        DoOnce = true;

    }
}
