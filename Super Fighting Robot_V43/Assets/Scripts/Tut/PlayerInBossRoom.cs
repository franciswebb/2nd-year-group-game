using UnityEngine;
using System.Collections;

public class PlayerInBossRoom : MonoBehaviour
{
    public GameObject TutaBoss;

    public AudioClip bossMusic;
    private AudioManager theAM;


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
            if (bossMusic != null)
            {
                theAM.ChangeBGM(bossMusic);
            }

            if (TutaBoss.active)
            {

                TutaBoss.GetComponent<TUTBoss>().playerInBossRoom = true;

            }

            return;

            //          GetComponent<TUTBoss>().playerInBossRoom = true;

        }

    }









}
