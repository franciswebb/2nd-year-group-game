using UnityEngine;
using System.Collections;

public class PlayerJumpTake3 : MonoBehaviour
{
    public float _timeHeld = 0.0f;
    public float _timeForFullJump = 2.0f;
    public float _minJumpForce = 0.5f;
    public float _maxJumpForce = 2.0f;
    public float _leftJumpForce = 1.0f;

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            _timeHeld = 0f;

        }

        if (Input.GetButton("Jump"))
        {
            _timeHeld += Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpingNow();
        }


    }




    public void jumpingNow()
    {



    }


}
