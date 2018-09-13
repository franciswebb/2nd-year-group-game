using UnityEngine;
using System.Collections;

public class FlyingBossParentTeleportFix : MonoBehaviour
{
    private bool playerLeftParent, playerInRangeParent;
    private FlyingBaddie flyingBaddie;
 
    // Use this for initialization

    void Start()
    {
        //       //     parentFlyer.position.x = parentFlyer.position.x + newTransformCheckerPos;

        flyingBaddie = GetComponent<FlyingBaddie>();
    //    playerLeftParent = flyingBaddie.playerLeft;
 //       playerInRangeParent = flyingBaddie.playerInRange;

    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position.x  = 100;

    }










}
