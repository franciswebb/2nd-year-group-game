using UnityEngine;
using System.Collections;

public class FollowFlyer : MonoBehaviour
{
    public Transform target;
    private Transform startTarget;
    public float speed = 3f;
    private CheckPlayerInRange playerInRangeScript;

    // Use this for initialization
    void Start()
    {
        startTarget = gameObject.transform;
        playerInRangeScript = GetComponent<CheckPlayerInRange>();
           // transform.localScale = new Vector3(-1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

        //move towards the player

        if (playerInRangeScript.playerInRange)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation

            //move if player in range
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));



        }


        /*
        if (playerInRangeScript.playerInRange==false)
        {
            transform.LookAt(startTarget.position);
         //   transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation

            transform.Translate(new Vector3(2f * Time.deltaTime, 0, 0));
        }

    */


        //  if(playerInRangeScript.playerInRange==false)
        //  {
        //     transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //
        // }


        //GetComponentInChildren<CheckPlayerInRange>().
        //   if (Vector3.Distance(transform.position, target.position) > 1f)

    }
}
