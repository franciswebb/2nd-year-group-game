using UnityEngine;
using System.Collections;

public class testCollidersAsVars : MonoBehaviour
{

    public BoxCollider2D KillTrigger;
    private AudioManager theAM;
    private Player player;

    private LevelManager levelManager;




    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        levelManager = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }





    void OnTriggerStay(Collider other)
    {

        if (other == KillTrigger)
        {
            if (other.tag == "Player")
            {
                Debug.Log("PLAYER COLLIDED WITH KILL TRIGGER IN SPINNY");
                theAM = FindObjectOfType<AudioManager>();
                theAM.BGM.Stop();

                player.DeathSFX.Play();

                levelManager.RespawnPlayer();

            }// end if player
        }//end if killtrigger


    }// end on trigger stay



}//// end all
