using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour
{

    //   private Player thePlayer;
    private Player laPlayer;


    // Use this for initialization
    void Start()
    {
        //        thePlayer = gameObject.GetComponent<Player>();
        laPlayer = FindObjectOfType<Player>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "MegaMan")
        {
            laPlayer.inLadderZone = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "MegaMan")
        {
            laPlayer.inLadderZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "MegaMan")
        {
            laPlayer.inLadderZone = false;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
