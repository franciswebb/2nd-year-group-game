using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    #region REF 
    // /* */
    #endregion


    #region VARIABLES

    #region visability var 
    public Renderer rend;
    #endregion

    #region Climbing
    public float climbSpeed;
    private float climbVelocity;
    public bool ExitTopLadder;
    private float gravityStore;
    #endregion

    #region Ground Check
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
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
    private HealthManager healthManager;
    #endregion

    #region Animation POS & BOOLs

    public bool canhit, hit = false, climbing, shooting, canDoubleJump,
                inLadderZone, isVis = true;
    public int shotPosInt = 1;

    #endregion

    #region Animator to change
    public Rigidbody2D rb2dPlayer;
    private Animator anim;
    #endregion

    #region SHOOTING LOCATION
    public Transform firePoint, firePoint2, firePoint3, firePoint4;
    public GameObject megaShot, rocket, water;
    public int WeaponCheck = 0;
    private GameObject CurrentWeapon;
    public bool needAmmo;
    private weaponAmmo weaponAmmo;
    private SwordHurtEnemy sword;
    #endregion

    #region Damage_Invins
    public float hitDelay;
    public float invinsibleDelay;
    public float canHitDelay;

    public int damageToGive;

    #region Blink Invic
    private float invicTime = 4, numOfLoopsOfBlink = 3;
    #endregion

    #endregion

    #region SOUNDFX
    public AudioSource firstJumpSFX;
    public AudioSource secondJumpSFX;
    public AudioSource landingSFX;

    public AudioSource shootSFX;

    public AudioSource hitSFX;
    public AudioSource DeathSFX;

    public AudioSource pickUpSFX;
    #endregion


    public bool playerRight = false;

    public float startTime;


    #endregion


    private bool wasMoving = false;
    private int horizBool = 0;



    #region All Colour Values 
    // /* */

    #region Normal vars                                                                   Normal
    public float[] normalColour = new float[4] { 1f, 1f, 1f, 1f };
    #endregion

    #region Red vars                                                                      FIRE
    public float[] redColour = new float[4] { 1f, 0.3f, 0.45f, 1f };
    #endregion

    #region Green vars                                                                    GRASS
    public float[] greenColour = new float[4] { 0f, 1f, 0f, 1f };
    #endregion

    #region Blue vars                                                                     WATER
    public float[] blueColour = new float[4] { 0.6f, 0.5f, 1f, 1.2f };
    #endregion


    //public float[] testColour = new float[4] { 0f, 1f, 0f, 1f };
    // public float[,] AllColourChange = new float[4] { 1f, 0.3f, 0.45f, 1f }; // FIND OUT HOW TO DO 2D ARRAYS

    #endregion

    void Start() // ASSIGNES BOTH RIGIDBODY AND ANIMATOR FOR ANIMATION STATE 
    {
        moveSpeedSneek = moveSpeed / 6;



        #region Takes how long your invinc, / how many blinks, / 2 each half of loop 
        // /* */


        invicTime = invicTime / numOfLoopsOfBlink; // / is with remainders % is not

        invicTime = invicTime / 2;
        #endregion



        /*
        if (jumpSFX.isActiveAndEnabled)
        {

        }else
        {

        }
        */
        sword = FindObjectOfType<SwordHurtEnemy>();
        weaponAmmo = GetComponent<weaponAmmo>();
        healthManager = GetComponent<HealthManager>();
        rb2dPlayer = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        canhit = true;
        gravityStore = rb2dPlayer.gravityScale;

    } // End Start


    void FixedUpdate()        // USED TO FRICTION 
    {

        //GetComponent<SpriteRenderer>().color = new Color(normalColour[0], normalColour[1], normalColour[2], normalColour[3]);


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        setFrictionToPlayer();


    }        // End Fixed Update


    void Update() // EVERY FRAME WILL RUN EACH OF THESE METHODS (ANIMATION STATES, CONTROL CHECK, BULLET SPAWN POSITION) 
    {
        animationStateInitialise();

        controlSetUpToWork();

        setShotPosInt();

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

        #region REF 
        // /* */
        #endregion

        #region Movement And Air Friction

        #region Rignt 
        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {//rotates when walking right
            rb2dPlayer.velocity = new Vector2(moveSpeed, rb2dPlayer.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            moveWasPressed = true;

            playerRight = true;
        }
        #endregion

        #region Left
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            rb2dPlayer.velocity = new Vector2(-moveSpeed, rb2dPlayer.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            moveWasPressed = true;

            playerRight = false;
        }
        #endregion

        #region Reset (No Movement no slide) 
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (moveWasPressed)
            {
                if (grounded)
                {
                    rb2dPlayer.velocity = new Vector2(0, 0);
                }
                moveWasPressed = false;
            }
        }
        #endregion


        #region Air Friction

        Vector3 easeVelocityAir = rb2dPlayer.velocity;                      // break float bassicaly
        easeVelocityAir.y = rb2dPlayer.velocity.y;
        easeVelocityAir.z = 0.0f;                                           // z is to and from in unity
        easeVelocityAir.x *= 0.655f;

        if (!grounded)                                                      // If not in air apply this velocity
            rb2dPlayer.velocity = easeVelocityAir;

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
        #endregion

        #endregion




        #region JUMP WORK NOW FOR HOLDING

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                if (canDoubleJump)
                    canDoubleJump = false;

                canDoubleJump = true;

              //  firstJumpSFX.Play();
            }//
            else//                                              not grounded in air
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                //    secondJumpSFX.Play();
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
            if (inLadderZone == true)
            {
                climbing = true;
            }
        }
        if (inLadderZone == true)
        {
            if (grounded == false)
            {
                rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            }
            else
            {
                rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            if (Input.GetButton("Jump"))
            {

                rb2dPlayer.gravityScale = gravityStore;
                climbing = false;
            }
            else
            {

                rb2dPlayer.gravityScale = 0f;
                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

                rb2dPlayer.velocity = new Vector2(rb2dPlayer.velocity.x, climbVelocity);
            }

        }
        if (inLadderZone == false)
        {
            if (ExitTopLadder == true)
            {
                rb2dPlayer.velocity = new Vector2(rb2dPlayer.velocity.x, 0);
            }
            rb2dPlayer.gravityScale = gravityStore;
            climbing = false;
            rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (healthManager.isDead == true)
            {
                rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

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
        int currentAmmo = weaponAmmo.currentAmmo;

        if (WeaponCheck == 0)
        {
            CurrentWeapon = megaShot;
            sword.turnOff();
            currentAmmo = weaponAmmo.currentAmmo;
        }
        if (WeaponCheck == 1)
        {
            CurrentWeapon = rocket;
            lemCount = 1;
            sword.turnOff();
            currentAmmo = weaponAmmo.currentAmmo;
        }
        if (WeaponCheck == 2)
        {
            CurrentWeapon = water;
            sword.turnOff();
            currentAmmo = weaponAmmo.currentAmmo;
        }
        if (WeaponCheck == 3)

        {

            CurrentWeapon = megaShot;
            currentAmmo = weaponAmmo.currentAmmo;

            if (currentAmmo > 0)
            {
                sword.turnOn();
            }
            else
            {
                sword.turnOff();
            }


        }

        if (shooting)
        {
            weaponAmmo.AmmoCheck();

            switch (shotPosInt)
            {
                case 0:             //                  get standing shootpos

                    ResetAnimations();
                    //shooting

                    break;

                case 1: // GET FRANKIE TO CHANGE TO ALL OF SWITCH SO AS CAN BE CHANGED IF WEAPONS CHANGED


                    if (shotCount < lemCount)
                    {

                        if (WeaponCheck < 3 && currentAmmo > 0)
                        {

                            Instantiate(CurrentWeapon, firePoint.position, firePoint.rotation);
                            shootSFX.Play();
                            weaponAmmo.TakeAwayAmmo();
                        }
                        else if (WeaponCheck == 3 && currentAmmo > 0)
                        {
                            sword.swordHit();
                            weaponAmmo.TakeAwayAmmo();
                        }

                    }


                    break;


                case 2:

                    if (shotCount < lemCount)
                    {
                        if (WeaponCheck < 3 && currentAmmo > 0)
                        {

                            Instantiate(CurrentWeapon, firePoint4.position, firePoint4.rotation);
                            shootSFX.Play();
                            weaponAmmo.TakeAwayAmmo();
                        }
                        else if (WeaponCheck == 3 && currentAmmo > 0)
                        {
                            sword.swordHit();
                            weaponAmmo.TakeAwayAmmo();
                        }

                    }
                    break;


                case 3:
                    if (shotCount < lemCount)
                    {
                        if (WeaponCheck < 3 && currentAmmo > 0)
                        {

                            Instantiate(CurrentWeapon, firePoint3.position, firePoint3.rotation);
                            shootSFX.Play();
                            weaponAmmo.TakeAwayAmmo();
                        }
                        else if (WeaponCheck == 3 && currentAmmo > 0)
                        {
                            sword.swordHit();
                            weaponAmmo.TakeAwayAmmo();
                        }


                    }

                    break;


                case 4:
                    if (shotCount < lemCount)
                    {
                        if (WeaponCheck < 3 && currentAmmo > 0)
                        {

                            Instantiate(CurrentWeapon, firePoint2.position, firePoint2.rotation);
                            shootSFX.Play();
                            weaponAmmo.TakeAwayAmmo();
                        }
                        else if (WeaponCheck == 3 && currentAmmo > 0)
                        {
                            sword.swordHit();
                            weaponAmmo.TakeAwayAmmo();
                        }


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


    /*
    public void Jump()
    {
        float verticalJumpForce = ((_maxJumpForce - _minJumpForce) * (_timeHeld / _timeForFullJump)) + _minJumpForce;
        if (verticalJumpForce > _maxJumpForce)
        {
            verticalJumpForce = _maxJumpForce;
        }
        Vector2 resolvedJump = new Vector2(-_leftJumpForce, verticalJumpForce);
        GetComponent<Rigidbody2D>().AddForce(resolvedJump, ForceMode2D.Impulse);
        Debug.Log(resolvedJump.ToString());
    }

        */




    void setFrictionToPlayer()// NEED TO FIX AND SORT WHEN RESIZE THE GAME 
    {




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
            if (healthManager.knockbackCheck == true)
            {
                if (knockFromRight)
                    rb2dPlayer.velocity = new Vector2(-knockback, knockback);
                if (!knockFromRight)
                    rb2dPlayer.velocity = new Vector2(knockback, knockback);
                knockbackCount -= Time.deltaTime;
            }
        }

    } // END set Friction To Player 




    public void Damage_Invins()
    {
        if (canhit == true)
        {
            HealthManager.HurtPlayer(damageToGive);
            hitSFX.Play();

            StartCoroutine("hitDelayCo");

            knockbackCount = knockbackLength;

            StartCoroutine("canHitDelayCo");

            healthManager.knockbackCheck = true;


        }


    }

    public void AnimeJump()
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
                rb2dPlayer.velocity = new Vector2(rb2dPlayer.velocity.x, jumpHeight / 2);
                //rb2dPlayer.AddForce(Vector2.up * jumpHeight / 1.75f);

                secondJumpSFX.Play();

            }//END                                                  DOUBLE JUMP
        }
    }

    public IEnumerator hitDelayCo()
    {
        hit = true;

        yield return new WaitForSeconds(hitDelay);
        hit = false;


    }


    public IEnumerator canHitDelayCo()
    {
        canhit = false;

        StartCoroutine("Flasher");
        yield return new WaitForSeconds(canHitDelay);
        canhit = true;


    }



    IEnumerator Flasher()
    {


        for (int i = 0; i < numOfLoopsOfBlink; i++)
        {

            rend.enabled = false;
            yield return new WaitForSeconds(invicTime);
            rend.enabled = true;
            yield return new WaitForSeconds(invicTime);


        }
    }


    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;

        }


        if (other.gameObject.tag == "Moving Ground Forward")
        {
            // transform.parent = other.transform;
            speed = 100;
            transform.Translate(0.05f, 0, 0);

        }


        if (other.gameObject.tag == "Moving Ground Backwards")
        {
            // transform.parent = other.transform;
            // speed = 7;
            transform.Translate(-0.05f, 0, 0);
        }

        // IF get Time get the way the player is moving and update this



    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;

        }


        if (other.gameObject.tag == "Moving Ground Forward")
        {
            // transform.parent = other.transform;
            speed = 30;

        }


        if (other.gameObject.tag == "Moving Ground Backwards")
        {
            // transform.parent = other.transform;
            speed = 30;
        }



    }





}




