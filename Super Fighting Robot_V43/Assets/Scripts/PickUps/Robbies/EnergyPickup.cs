using UnityEngine;
using System.Collections;

public class EnergyPickup : MonoBehaviour
{

    private EnergyTankManager energySystem;
    private Player player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();

        energySystem = FindObjectOfType<EnergyTankManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "MegaMan")
        {


            player.pickUpSFX.pitch = 1f;
            player.pickUpSFX.Play();

            energySystem.GiveEnergyTank();
            Destroy(gameObject);
        }
    }
}