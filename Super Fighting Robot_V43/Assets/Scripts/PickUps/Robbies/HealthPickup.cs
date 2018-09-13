using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
    public int healthToGive;

    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null)
            return;


        HealthManager.HealPlayer(-healthToGive);

        if (healthToGive < -15)
        {
            // big health
            player.pickUpSFX.pitch = 1.25f;

            player.pickUpSFX.Play();
            Destroy(gameObject);
        }



        if (healthToGive > -15)
        {
            player.pickUpSFX.pitch = 1.75f;
            player.pickUpSFX.Play();
            Destroy(gameObject);

            // small one
        }
    }





}
