using UnityEngine;
using System.Collections;


public class BossMusicSwitch : MonoBehaviour
{

    public bool inBossRoom = false;



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inBossRoom = true;


        }
    }
}




