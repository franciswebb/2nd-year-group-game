using UnityEngine;
using System.Collections;

public class WoodBoss2 : MonoBehaviour
{

    public bool shoot, playerInBossRoom=false;
    private Animator anim;

    public GameObject slimeShot;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Shoot", shoot);

        if(playerInBossRoom)
        {
            shoot = true;
        }

    }


    void Shooting()
    {


    }



}
