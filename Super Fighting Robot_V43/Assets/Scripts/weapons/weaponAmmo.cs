using UnityEngine;
using System.Collections;

public class weaponAmmo : MonoBehaviour
{

    public int fireAmmo, waterAmmo, grassAmmo, megaAmmo = 1000000, currentAmmo = 10, ammoloss;
    private SwordHurtEnemy sword;
    private Player player;
    // Use this for initialization
    void Start()
    {
        
        player = FindObjectOfType<Player>();
        sword = FindObjectOfType<SwordHurtEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeAwayAmmo()
    {
        switch (player.WeaponCheck)
        {
            case 0:
                megaAmmo -= ammoloss;
                break;

            case 1:
                fireAmmo -= ammoloss;
                break;

            case 2:
                waterAmmo -= ammoloss;
                break;

            case 3:
                grassAmmo -= ammoloss;
                break;
        }
    }

    public void AddAmmo(int ammoToGive)
    {
        switch (player.WeaponCheck)
        {
            case 0:
                megaAmmo += ammoToGive;
                break;

            case 1:
                fireAmmo += ammoToGive;
                if (fireAmmo > 10)
                {
                    fireAmmo = 10;
                }
                break;

            case 2:
                waterAmmo += ammoToGive;
                if (waterAmmo > 10)
                {
                    waterAmmo = 10;
                }
                break;

            case 3:
                grassAmmo += ammoToGive;
                if (grassAmmo > 10)
                {
                    grassAmmo = 10;
                }
                break;
        }
    }

    public void AmmoCheck()
    {
        switch (player.WeaponCheck)
        {
            case 0:
                currentAmmo = megaAmmo;
                break;

            case 1:
                currentAmmo = fireAmmo;
                break;

            case 2:
                currentAmmo = waterAmmo;
                break;

            case 3:
                currentAmmo = grassAmmo; 
               
              
              
                break;
        }



    }
    public int getAmmo()
    {
        return currentAmmo;
    }
}
