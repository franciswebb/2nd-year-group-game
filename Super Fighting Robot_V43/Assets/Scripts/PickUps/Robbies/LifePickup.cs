using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour
{
    private LifeManager lifeSystem;
    private Player player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "MegaMan")
        {

            player.pickUpSFX.pitch = 2f;
            player.pickUpSFX.Play();
            lifeSystem.GiveLife();
            Destroy(gameObject);
        }
    }
}

