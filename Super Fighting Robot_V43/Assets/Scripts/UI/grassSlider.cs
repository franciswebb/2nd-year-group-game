using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class grassSlider : MonoBehaviour
{
    private HealthManager healthManager;
    private Slider grassBar;
    private weaponAmmo ammo;

    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        grassBar = GetComponent<Slider>();
        ammo = FindObjectOfType<weaponAmmo>();
        grassBar.value = 0;

    }

    // Update is called once per frame
    void Update()
    {
        grassBar.value = (10 - ammo.grassAmmo);
    }
}
