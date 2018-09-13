using UnityEngine;
using System.Collections;

public class LadderExitTop : MonoBehaviour {
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
            laPlayer.ExitTopLadder = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "MegaMan")
        {
            laPlayer.ExitTopLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "MegaMan")
        {
            laPlayer.ExitTopLadder = false;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
