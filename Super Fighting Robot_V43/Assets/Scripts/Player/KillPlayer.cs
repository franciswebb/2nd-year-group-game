using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{


    private AudioManager theAM;
    private Player player;
    private HealthManager health;
    public LevelManager levelManager;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        levelManager = FindObjectOfType<LevelManager>();
        health = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theAM = FindObjectOfType<AudioManager>();
            theAM.BGM.Stop();

            player.DeathSFX.Play();
            health.isDead = true;
           
            levelManager.RespawnPlayer();

        }
    }
}
