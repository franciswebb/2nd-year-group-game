using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{



    public bool isPaused;
    public bool isAxisInUse = true;

    private int weaponCheck;
    public Text Tanks;
    public HealthManager healthManager;

    public GameObject weaponMenuCanvas, fireSlider, waterSlider, grassSlider;

    public EnergyTankManager energyTankManager;
    public Player player;
    public int tanks, newTanks = 3;

    public MegaCloud cloud;

    void start()
    {
        
        cloud = FindObjectOfType<MegaCloud>();
        player = FindObjectOfType<Player>();
        fireSlider = GetComponent<GameObject>();
        waterSlider = GetComponent<GameObject>();
        grassSlider = GetComponent<GameObject>();
       
        energyTankManager = FindObjectOfType<EnergyTankManager>();
        healthManager = FindObjectOfType<HealthManager>();

        waterSlider.SetActive(false);
        fireSlider.SetActive(false);
        grassSlider.SetActive(false);
        Tanks.text = newTanks.ToString();


    }


    // Update is called once per frame
    void Update()
    {
        cloud = FindObjectOfType<MegaCloud>();
        if (isPaused)
        {
            weaponMenuCanvas.SetActive(true);

            Time.timeScale = 0f;
            player.enabled = false;

        }
        else
        {
            weaponMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            player.enabled = true;
        }


        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;

        }




    }

    void UpDownMovement()
    {

        if ((Input.GetButtonDown("Up")))
        {
            Debug.Log("UP");
            Debug.Log(weaponCheck);
            weaponCheck++;

        }



        if ((Input.GetButtonDown("Down")))
        {
            Debug.Log("DOWN");
            Debug.Log(weaponCheck);
            weaponCheck--;

        }


    }

    void SelectAxisDown()
    {
        if (Input.GetAxisRaw("Climb") < 0)
        {
            Debug.Log("PRESSED");
            if (isAxisInUse == false)
            {
                weaponCheck--;
                isAxisInUse = true;
            }// end if axis
        }// end axis raw not 0
        if (Input.GetAxisRaw("Climb") > 0)
        {

            if (isAxisInUse == false)
            {
                weaponCheck++;
                isAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            isAxisInUse = false;
        }

    }// end slect axis



    void WeaponSelecter()
    {
       
        switch (weaponCheck)
        {
            case 1:
                NormalPlayerEnabled();
                Debug.Log("1");


                break;//Normal Lemon Player 

            case 2:
                FireWeaponEnabled();
                Debug.Log("2");

                break;//Fire Weapon

            case 3:
                WaterWeaponEnabled();
                Debug.Log("3");

                break;//Water Weapon
            case 4:

                GrassWeaponEnabled();
                Debug.Log("4");
                break;//Grass Weapon

            case 5:

                EnergyTankEnabled();
                Debug.Log("5");

                break;//Energy Tank Button

            default:
                break;
        }
    }

    public void NormalPlayerEnabled()
    {
        player.GetComponent<SpriteRenderer>().color = new Color(255f, 70f, 70f, 1f);

        waterSlider.SetActive(false);
        fireSlider.SetActive(false);
        grassSlider.SetActive(false);
        player.WeaponCheck = 0;
        Debug.Log("NORMAL PLAYER ONLY");
        isPaused = !isPaused;

    }

    public void WaterWeaponEnabled()
    {
        if (cloud.waterFinished_Cloud == true)
       {
        player.GetComponent<SpriteRenderer>().color = new Color(player.blueColour[0], player.blueColour[1], player.blueColour[2], player.blueColour[3]);

        waterSlider.SetActive(true);
        fireSlider.SetActive(false);
        grassSlider.SetActive(false);
        player.WeaponCheck = 2;
        Debug.Log("WATER WEAPON ENGAGED");
        isPaused = !isPaused;
        }
        else
        {
           isPaused = !isPaused;
           player.GetComponent<SpriteRenderer>().color = new Color(player.normalColour[0], player.normalColour[1], player.normalColour[2], player.normalColour[3]);

        }
    }

    public void FireWeaponEnabled()
    {

        if(cloud.fireFinished_Cloud==true)
       {

        player.GetComponent<SpriteRenderer>().color = new Color(player.redColour[0], player.redColour[1], player.redColour[2], player.redColour[3]);

        fireSlider.SetActive(true);
        grassSlider.SetActive(false);
        waterSlider.SetActive(false);
        player.WeaponCheck = 1;
        Debug.Log("FIRE WEAPON ENGAGED");
        isPaused = !isPaused;
        }
        else
        {
            isPaused = !isPaused;
            player.GetComponent<SpriteRenderer>().color = new Color(player.normalColour[0], player.normalColour[1], player.normalColour[2], player.normalColour[3]);

        }
    }

    public void GrassWeaponEnabled()
    {
        if (cloud.woodFinished_Cloud == true)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(player.greenColour[0], player.greenColour[1], player.greenColour[2], player.greenColour[3]);

            grassSlider.SetActive(true);
            fireSlider.SetActive(false);
            waterSlider.SetActive(false);
            player.WeaponCheck = 3;
            Debug.Log("GRASS WEAPON ENGAGED");
            isPaused = !isPaused;
        }
        else
        {
            isPaused = !isPaused;
            player.GetComponent<SpriteRenderer>().color = new Color(player.normalColour[0], player.normalColour[1], player.normalColour[2], player.normalColour[3]);

        }
    }

    public void EnergyTankEnabled()
    {
        tanks = newTanks;
        if (tanks >= 1)
        {
            healthManager.FullHealth();
            newTanks--;
            Tanks.text = newTanks.ToString();
        }

        else
        {
            Debug.Log("NO ENERGY TANKS AVAILABLE");
        }
        //  healthManager.FullHealth();
        //   energyTankManager.UseEnergyTank();

        //   if (energyTankManager.noOfTanks >= 1)
        // {

        //healthManager.HealthGradIncrease();
        //  healthManager.FullHealth();
        //energyTankManager.noOfTanks--;
        //Debug.Log("ENERGY TANK HEALTH INCREASE");

        // Debug.Log("Energy Tank Used");
        //  }
        //else
        //  {
        //      Debug.Log("NO ENERGY TANKS AVAILABLE");
        //  }

    }



}//pauseMenu
