using UnityEngine;
using System.Collections;

public class BarrelMon : MonoBehaviour
{
    public Transform shootingPosis;
    public GameObject TUT_BarrelShot;
    private CheckPlayerInRange playerRange;
    private Animator anim;
    private bool shooting = false, doOnce = false;
    private Player playPersonLoca;
    private Vector3 playerLocationVec3;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        playerRange = GetComponent<CheckPlayerInRange>();
        playPersonLoca = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        animationStateInitialise();


        if (playerRange.playerInRange)
        {
            shooting = true;
            doOnce = true;
        }
        else
        {
            shooting = false;
            doOnce = false;
        }

    }



    void ShootingStartAnimation()
    {
        if (doOnce)
        {
            playerLocationVec3 = playPersonLoca.transform.position;
        }



    }


    void ShootingShootNowAnimation()
    {
        if (playerRange.playerLeft)
            Instantiate(TUT_BarrelShot, shootingPosis.position, shootingPosis.rotation);
        //       TUT_BarrelShot.transform.position = Vector3.Lerp(shootingPosis.position, playerLocationVec3, 6.28f * 0.5f * Time.time);          // MID ONE IS SPEED



    }

    void animationStateInitialise()
    {
        anim.SetBool("Is Shooting", shooting);
    }

}

