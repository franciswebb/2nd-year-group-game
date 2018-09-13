using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{

    private Player player; //links to the player c# file
    private bool doOnce; // used to make sure it only plays sound efx one time when stays on collide

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();



    }

}