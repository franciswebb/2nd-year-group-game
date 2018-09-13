using UnityEngine;
using System.Collections;

public class fireBossShootWeapon : MonoBehaviour
{

    public Transform explodePoint;
    public GameObject weapon;
    private float flyerLocation2, playerLocation2, checkerOfTheDistance;
    // Use this for initialization
    void Start()
    {

        checkerOfTheDistance = flyerLocation2 - playerLocation2;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShootWeapon()
    { 
        Instantiate(weapon, explodePoint.position, explodePoint.rotation);
    }
}
