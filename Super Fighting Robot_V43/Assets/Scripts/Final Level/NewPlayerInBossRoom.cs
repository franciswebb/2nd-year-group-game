using UnityEngine;
using System.Collections;

public class NewPlayerInBossRoom : MonoBehaviour
{
    private AudioManager theAM;
    public AudioClip bossMusic, resetMusic;


    public bool playerHasEntered = false;

    // Use this for initialization
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {



            playerHasEntered = true;

            if (bossMusic != null)
            {
                theAM.ChangeBGM(bossMusic);
            }


            //          GetComponent<TUTBoss>().playerInBossRoom = true;

        }

    }


    void OnTriggerExits2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHasEntered = false;
            // do Frankies thing

            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            if (bossMusic != null)
            {
                theAM.ChangeBGM(bossMusic); // reset back to normal music
            }


            //          GetComponent<TUTBoss>().playerInBossRoom = true;

        }

    }




}
