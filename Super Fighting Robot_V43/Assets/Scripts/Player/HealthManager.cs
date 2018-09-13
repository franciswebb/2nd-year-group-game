using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    private AudioManager theAM;


    public int maxPlayerHealth;

    public static int playerHealth;

    private LevelManager levelManager;
    private LifeManager lifeManager;
   
    public bool isDead;
    public Player player;
    public int canHitDelay;
    public bool knockbackCheck = true;


    // Use this for initialization
    void Start()
    {

        playerHealth = maxPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();
        lifeManager = FindObjectOfType<LifeManager>();


        isDead = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth >= 100 && !isDead)
        {
            
            
                theAM = FindObjectOfType<AudioManager>();
                theAM.BGM.Stop();
                knockbackCheck = false;

                player.DeathSFX.Play();

                levelManager.RespawnPlayer();
                
                isDead = true;
            
        }

    }

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth += damageToGive;
        if (playerHealth > 100)
        { 
            playerHealth = 100;
        }
        Debug.Log("Players Health = " + playerHealth);

    }
	
	public static void HealPlayer(int healthToGive)		
    {		
        playerHealth -= healthToGive;
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public int PlayerDied()
    {
        playerHealth = 100;
        return playerHealth;
    }


}