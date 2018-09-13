using UnityEngine;
using System.Collections;

public class AudioManagerCheck : MonoBehaviour
{

    public GameObject audioMan;
    private Vector3 SpawnLocation;

    // Use this for initialization
    void Start()
    {

        SpawnLocation = transform.position;
        SpawnLocation.x = SpawnLocation.x + 20;

        if (FindObjectOfType<AudioManager>())
        {
            return;
        }
        else
        {
            Instantiate(audioMan, SpawnLocation, transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
