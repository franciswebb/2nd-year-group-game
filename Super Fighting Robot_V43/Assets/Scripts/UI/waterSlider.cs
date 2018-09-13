using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waterSlider : MonoBehaviour {

    private HealthManager healthManager;
    private Slider waterBar;
    private weaponAmmo ammo;

    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        waterBar = GetComponent<Slider>();
        ammo = FindObjectOfType<weaponAmmo>();
        waterBar.value = 0;

    }

    // Update is called once per frame
    void Update()
    {
        waterBar.value = (10 - ammo.waterAmmo);
    }
}
