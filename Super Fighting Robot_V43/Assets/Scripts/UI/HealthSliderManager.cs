using UnityEngine;
using UnityEngine.UI;

public class HealthSliderManager : MonoBehaviour {

    private HealthManager healthManager;
    private Slider healthBar;
    private weaponAmmo ammo;

	// Use this for initialization
	void Start () {
        healthManager = FindObjectOfType<HealthManager>();
        healthBar = GetComponent<Slider>();

        healthBar.value = healthManager.GetPlayerHealth();
     
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.value = healthManager.GetPlayerHealth();
    
    }

    
}
