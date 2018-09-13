using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour
{

    #region VARIABLES

    #region REF 
    // /* */
    #endregion

    #region visability var 
    public Renderer rend;
    #endregion

    #region Ground Check
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    #endregion

    #region Speed and Jump
    public float speed = 30f;
    public float moveVelocity = 30f;


    public float moveSpeed = 5;
    public float moveSpeedSneek = 5;
    private bool moveWasPressed = false;

    public float jumpHeight = 150f;
    #endregion

    #region KNOCKBACK VAR
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    #endregion

    #region Animation POS & BOOLs
    public bool canhit, hit = false, climbing, shooting, canDoubleJump,
        inLadderZone, isVis = true;
    public int shotPosInt = 1;
    #endregion

    #region Animator to change
    private Rigidbody2D rb2dPlayer;
    private Animator anim;
    #endregion

    #region SHOOTING LOCATION
    public Transform firePoint, firePoint2, firePoint3, firePoint4;
    public GameObject megaShot;
    #endregion

    #region SOUNDFX
    public AudioSource firstJumpSFX;
    public AudioSource secondJumpSFX;
    public AudioSource landingSFX;

    public AudioSource shootSFX;

    public AudioSource hitSFX;
    public AudioSource DeathSFX;
    #endregion

    #region testingGetRidOf
    private float invicTime = 4, numOfLoopsOfBlink = 3;

    #endregion


    // 0.3 is value of pushed

    // GetComponent<INSET THE THING ATTACTED TO THE THING THIS IS ATTACHED TO HERE , if in player want helth put in helthmanager script name here>();





    #endregion


    private bool wasMoving = false;
    private int horizBool = 0;






    void Start() // ASSIGNES BOTH RIGIDBODY AND ANIMATOR FOR ANIMATION STATE 
    {

        moveSpeedSneek = moveSpeed / 6;


        Debug.Log(invicTime + " INVINC TIME PLAYER start");

        invicTime = invicTime / numOfLoopsOfBlink; // / is with remainders % is not

        Debug.Log(invicTime + " INVINC TIME PLAYER divid num (3)");

        invicTime = invicTime / 2;

        Debug.Log(invicTime + " INVINC TIME PLAYER divid 2 for both");


        /*
        if (jumpSFX.isActiveAndEnabled)
        {

        }else
        {

        }
        */

        rb2dPlayer = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        canhit = true;
    } // End Start


    void FixedUpdate()        // USED TO FRICTION 
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        setFrictionToPlayer();


    }        // End Fixed Update


    void Update() // EVERY FRAME WILL RUN EACH OF THESE METHODS (ANIMATION STATES, CONTROL CHECK, BULLET SPAWN POSITION) 
    {
        animationStateInitialise();

        controlSetUpToWork();

        setShotPosInt();


        Debug.Log(invicTime + " INVINC TIME PLAYER");
        Debug.Log(Input.GetAxisRaw("Horizontal") + " Horizontal value ");

    } //End                                                             Update















    void animationStateInitialise()// THIS IS THE UPDATE THAT TAKES BOOL SETS TO ANIMATION STATES 
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2dPlayer.velocity.x));
        //anim.SetFloat("Speed", Input.GetAxisRaw("Horizontal"));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Hit", hit);
        anim.SetBool("Climbing", climbing);
        anim.SetBool("Shooting", shooting);
    }// END ANIMATION STATE

    void controlSetUpToWork()// NEED TO FIX HIT WHEN KB AND ALL IS DONE 
    {




        #region Axis to button This is Probably what your dude was on about that
        /*
        if (Input.GetAxis("Horizontal") > 0.01f)
        {//rotates when walking right
            horizBool = 1;
        }
        if (Input.GetAxis("Horizontal") < -0.01f)
        {
            horizBool = -1;

        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            horizBool = 0;

        }
        */
        #endregion









        #region Movement Left Right

        #region OLD TO REMOVE
        /*
        // TAKES THE SPRITE AND ROTATES IF GOING LEFT
        if (Input.GetAxis("Horizontal") < -0.01f)
        {//rotates when walking left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.01f)
        {//rotates when walking right

            transform.localScale = new Vector3(1, 1, 1);
        }
        // END TAKES THE SPRITE AND ROTATES IF GOING LEFT
        */
        #endregion

        #region Sebastions Jump


        #endregion


        #region GAMES PLUS JAMES VERSION

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {//rotates when walking right

            rb2dPlayer.velocity = new Vector2(moveSpeed, rb2dPlayer.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            moveWasPressed = true;

        }
        if (Input.GetAxisRaw("Horizontal") < -0.1f)                                 //0.3 is the sneekie wan
        {//rotates when walking left
            rb2dPlayer.velocity = new Vector2(-moveSpeed, rb2dPlayer.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            moveWasPressed = true;

        }



        /*
        if (Input.GetAxisRaw("Horizontal") > 0.01f && Input.GetAxisRaw("Horizontal") < 0.3f)
        {//rotates when walking right
            Debug.Log("YAYAYAYAYAY!");
            rb2dPlayer.velocity = new Vector2(moveSpeedSneek, rb2dPlayer.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            moveWasPressed = true;

        }
        if (Input.GetAxisRaw("Horizontal") < -0.01f && Input.GetAxisRaw("Horizontal") < -0.3f)
        {//rotates when walking left
            Debug.Log("YAYAYAYAYAY22222222222222222222222222222!");
            rb2dPlayer.velocity = new Vector2(-moveSpeedSneek, rb2dPlayer.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            moveWasPressed = true;
        }
        */



        if (Input.GetAxisRaw("Horizontal") == 0)
        {//rotates when walking left
            if (moveWasPressed)
            {

                if (grounded)
                {
                    rb2dPlayer.velocity = new Vector2(0, 0);
                }

                moveWasPressed = false;
            }

        }



        Vector3 easeVelocityAir = rb2dPlayer.velocity;                  // break float bassicaly
        easeVelocityAir.y = rb2dPlayer.velocity.y;
        easeVelocityAir.z = 0.0f;                  //z is to and from in unity
        easeVelocityAir.x *= 0.655f;

        if (!grounded)
            rb2dPlayer.velocity = easeVelocityAir; 







        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");




        #endregion



        #endregion



        #region JUMP

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                //rb2dPlayer.AddForce(Vector2.up * jumpHeight);
                rb2dPlayer.velocity = new Vector2(rb2dPlayer.velocity.x, jumpHeight);    //GetComponent<Rigidbody2D>().position.x, jumpHeight);
                                                                                         // GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().position.x, jumpHeight);    //GetComponent<Rigidbody2D>().position.x, jumpHeight);
                canDoubleJump = true;

                firstJumpSFX.Play();

            }//         CHECKS IF ON THE GROUND WHEN JUMPS PRESSED AND JUMPS IF CAN
            else//                                              not grounded in air
            {
                if (canDoubleJump)
                {//     IF DJ IS TRUE TURN OFF THEN JUMPS AGAIN 1/3 OF THE NORMAL
                    canDoubleJump = false;
                    rb2dPlayer.velocity = new Vector2(rb2dPlayer.velocity.x, jumpHeight/2);
                    //rb2dPlayer.AddForce(Vector2.up * jumpHeight / 1.75f);

                    secondJumpSFX.Play();

                }//END                                                  DOUBLE JUMP
            }

        }//End                                                          Jump
        #endregion



        #region SHOOT CONTROL
        //SHOTING                                         FIND HOW TO MAKE CONTROLS
        if (Input.GetButtonDown("MegaBuster"))
        {
            GameObject[] shotsToFind = GameObject.FindGameObjectsWithTag("Bullets");
            shooting = true;


        }
        #endregion




        #region CLIMB TEST  CLIMB BUTTON
        //CLIMBING                                         FIND HOW TO MAKE CONTROLS
        if (Input.GetButtonDown("Climb"))
        {
            if (climbing)
            {
                climbing = false;
            }
            else
            {
                climbing = true;
            }
        }
        //END CLIMBING                                                    CONTROLS
        #endregion
        #region HIT TEST X
        //HIT  FIND HOW TO TAKE AWAY CONTROL AND MAKE ANIMATION FINISH AND KNOCKBACK
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (hit)
            {
                hit = false;
                Debug.Log("HELL HIT FALSE");
            }
            else
            {
                Debug.Log("HELL HIT TRUE");
                hit = true;
            }
        }// END TOGGLE TO TEST HIT ANIMATIONS
        #endregion





        #region TEST INVINCE BLINK WITH Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("T was pressed to test");
            blinkCheck2();
        }
        #endregion
        #region GET RID OF OLD BLINK CHECK T
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T was pressed to test");
            blinkCheck();
        }// END TOGGLE TO TEST HIT ANIMATIONS
        #endregion



    } // END THE CONTROL SET UP METHOD


    #region SHOOT
    void setShotPosInt()// THIS IS CHECKING WHERE THE BULLET SHOULD BE SPAWNING FROM 
    {


        if ((shooting == false) && (grounded) && (climbing == false) && (hit == false) && (canDoubleJump) && (rb2dPlayer.velocity.x < 0.1))
        {
            shotPosInt = 0;
            //Idle
        }
        if ((shooting == true) && (grounded) && (climbing == false) && (hit == false) && (canDoubleJump) && (rb2dPlayer.velocity.x < 0.1))
        {
            shotPosInt = 1;
            //stand shoot
        }
        if ((shooting == true) && (grounded) && (climbing == false) && (hit == false) && (canDoubleJump) && (rb2dPlayer.velocity.x > 0.1))
        {
            shotPosInt = 2;
            //run shoot
        }
        if ((shooting == true) && (grounded == false) && (climbing == false) && (hit == false))
        {
            shotPosInt = 3;
            //jump shoot
        }
        if ((shooting == true) && (grounded == false) && (climbing == true) && (hit == false))
        {
            shotPosInt = 4;
            //climb shoot
        }

    }// END THE SET SHOT POSSITION


    void RunShootPressCheck() // SECONDARY CHECK IF THE PLAYER IS PRESSING THE E BUTTON AGAIN       ANIMATION CALLS PEW MULTIPLE TIMES AS SO PLAYTER CAN SHOOT MORE RAPIDLY 
    {
        /*
        if (Input.GetButtonUp("MegaBuster"))
        {
            shooting = false;

        }
        */

        if (Input.GetButtonDown("MegaBuster"))
        {
            shooting = true;
            PewPew();
        }
    } // END IF PRESSING SHOOT CHECK        RUNSHOOTPRESSCHECK

    void PewPew()// MAKES THE BULLET SPAWN     CALLED AND MADE THROUGH SHOOTING ANIMATIONS              
    {

        //setShotPosInt();

        GameObject[] shotsToFind = GameObject.FindGameObjectsWithTag("Bullets");

        int shotCount = shotsToFind.Length;
        int lemCount = 3;

        if (shooting)
        {


            switch (shotPosInt)
            {
                case 0:             //                  get standing shootpos

                    ResetAnimations();
                    //shooting

                    Debug.Log("The number is zero! RESET ALL");
                    break;

                case 1: // GET FRANKIE TO CHANGE TO ALL OF SWITCH SO AS CAN BE CHANGED IF WEAPONS CHANGED


                    if (shotCount < lemCount)
                    {

                        Instantiate(megaShot, firePoint.position, firePoint.rotation);

                        shootSFX.Play();
                    }

                    Debug.Log("Stand!");

                    break;


                case 2:

                    Debug.Log("Run!");
                    if (shotCount < lemCount)
                    {

                        Instantiate(megaShot, firePoint4.position, firePoint4.rotation);
                        shootSFX.Play();
                    }
                    break;


                case 3:
                    if (shotCount < lemCount)
                    {
                        Instantiate(megaShot, firePoint3.position, firePoint3.rotation);
                        shootSFX.Play();

                    }

                    Debug.Log("Jump!");
                    break;


                case 4:
                    if (shotCount < lemCount)
                    {
                        Instantiate(megaShot, firePoint2.position, firePoint2.rotation);
                        shootSFX.Play();

                    }
                    Debug.Log("Climb!");

                    break;



                default:
                    Debug.Log("Default case");
                    break;
            }

        }

        shooting = false;
    }// END PEW PEW
    #endregion

    #region Test flash 1 , 2
    void blinkCheck()
    {
        Debug.Log("got to blink check");
        StartCoroutine("Flasher");


    }


    IEnumerator Flasher()
    {

        Debug.Log("got to flasher");

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Start of loop");

            rend.enabled = false;
            yield return new WaitForSeconds(.1f);
            rend.enabled = true;
            yield return new WaitForSeconds(.1f);

            Debug.Log("End of Loop");

        }
    }






    void blinkCheck2()
    {
        Debug.Log("got to blink check");
        StartCoroutine("Flasher2");


    }


    IEnumerator Flasher2()
    {

        Debug.Log("got to flasher");

        for (int i = 0; i < numOfLoopsOfBlink; i++)
        {
            Debug.Log("Start of loop");

            rend.enabled = false;
            yield return new WaitForSeconds(invicTime);
            rend.enabled = true;
            yield return new WaitForSeconds(invicTime);

            Debug.Log("End of Loop");

        }
    }
    #endregion




    #region RESET ANIMATIONS
    IEnumerator MyCoroutine()// THIS IS APPARENTLY NEEDED TO DO A DELAY 
    {
        //This is a coroutine
        Debug.Log("got to corthing");

        yield return 0.25f;    // Wait set frame

        ResetAnimations();

    }

    void ResetAnimations()// SETS ALL BOOLS TO IDLE 
    {
        grounded = true;
        hit = false;
        climbing = false;
        shooting = false;
        canDoubleJump = true;

    }
    #endregion



    void setFrictionToPlayer()// NEED TO FIX AND SORT WHEN RESIZE THE GAME 
    {
        /*
        Vector3 easeVelocity = rb2dPlayer.velocity;
        easeVelocity.y = rb2dPlayer.velocity.y;
        easeVelocity.z = 0.0f;                  //z is to and from in unity
        easeVelocity.x *= 0.95f;
        //                                          Set friction velocity grounded


        Vector3 easeVelocityAir = rb2dPlayer.velocity;
        easeVelocityAir.y = rb2dPlayer.velocity.y;
        easeVelocityAir.z = 0.0f;                  //z is to and from in unity
        easeVelocityAir.x *= 0.855f;
        //                                 Set friction velocity grounded

        if (grounded)
        {
            rb2dPlayer.velocity = easeVelocity;
        }
        else
        {
            rb2dPlayer.velocity = easeVelocityAir;
        }
        */



        float controlsHoriz = Input.GetAxisRaw("Horizontal");
        rb2dPlayer.AddForce((Vector2.right * speed) * controlsHoriz);

        if (knockbackCount <= 0)
        {
            if (rb2dPlayer.velocity.x > moveSpeed)
            {
                rb2dPlayer.velocity = new Vector2(moveSpeed, rb2dPlayer.velocity.y);
            }

            if (rb2dPlayer.velocity.x < -moveSpeed)
            {
                rb2dPlayer.velocity = new Vector2(-moveSpeed, rb2dPlayer.velocity.y);
            }
        }
        else
        {
            if (knockFromRight)
                rb2dPlayer.velocity = new Vector2(-knockback, knockback);
            if (!knockFromRight)
                rb2dPlayer.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }

    } // END set Friction To Player 

}