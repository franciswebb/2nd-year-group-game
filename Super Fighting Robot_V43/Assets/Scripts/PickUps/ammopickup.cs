using UnityEngine;
using System.Collections;

public class ammopickup : MonoBehaviour
    
{

    public int ammoToGive;

    private Player player;
    private weaponAmmo ammo;

    void Start()
    {
        ammo = FindObjectOfType<weaponAmmo>();
        player = FindObjectOfType<Player>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            ammo.AddAmmo(ammoToGive);

            player.pickUpSFX.pitch = 1.25f;

            player.pickUpSFX.Play();

            Destroy(gameObject);

        }
    }
}

