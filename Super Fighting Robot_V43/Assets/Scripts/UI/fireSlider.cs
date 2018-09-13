using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fireSlider : MonoBehaviour {
    private HealthManager healthManager;
    private Slider fireBar;
    private weaponAmmo ammo;

    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        fireBar = GetComponent<Slider>();
        ammo = FindObjectOfType<weaponAmmo>();
        fireBar.value = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        fireBar.value = (10-ammo.fireAmmo);
    }
}
