using UnityEngine;
using UnityEngine.UI;


public class EnergyTankManager : MonoBehaviour {

    public int startNoOfTanks;
    public int noOfTanks;
    public int rando = 2;
   // public Text str_startNoOfTanks;

    public HealthManager healthManager;

    private PauseMenu pause;
    // Use this for initialization
    void Start () {
        healthManager = FindObjectOfType<HealthManager>();
       
        pause = FindObjectOfType<PauseMenu>();
        noOfTanks = 3;
        //str_startNoOfTanks.text = pause.newTanks.ToString();

    }
    void Update()
    {

    }
    public void UseEnergyTank()
    {
        if (rando >= 1)
        {

            //healthManager.HealthGradIncrease();
            healthManager.FullHealth();
            startNoOfTanks--;
            //Debug.Log("ENERGY TANK HEALTH INCREASE");
            
           // Debug.Log("Energy Tank Used");
        }
        else
       {
            Debug.Log("NO ENERGY TANKS AVAILABLE");
       }
        
        

    }
    
    public int GetEnergyTankAmount()
    {
        return noOfTanks;
       
    }
    public void GiveEnergyTank()
    {
        pause.newTanks++;

        pause.Tanks.text = pause.newTanks.ToString();
    }

}
