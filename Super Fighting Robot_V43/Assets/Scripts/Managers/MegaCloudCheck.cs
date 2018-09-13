using UnityEngine;
using System.Collections;

public class MegaCloudCheck : MonoBehaviour
{
    public GameObject cloudToMake;
    private Vector3 SpawnLocation;

    // Use this for initialization
    void Start()
    {
   
        SpawnLocation = transform.position;
        SpawnLocation.x = SpawnLocation.x + 20;

        if (FindObjectOfType<MegaCloud>())
        {
            return;
        }
        else
        {
            Instantiate(cloudToMake, SpawnLocation, transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
