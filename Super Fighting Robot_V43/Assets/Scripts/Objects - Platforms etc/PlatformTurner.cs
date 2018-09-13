using UnityEngine;
using System.Collections;

public class PlatformTurner : MonoBehaviour
{
    public BoxCollider2D KillTrigger;

    private LevelManager levelManager;

    public float delayTime;
    public GameObject startPos, endPos;
    private Vector3 posA, posB, currentPos;
    private bool moveRight = false, willSpin = false, moveBack = false;

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        posA = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
        posB = new Vector3(endPos.transform.position.x, endPos.transform.position.y, 0);

        transform.position = posA;

        //StartCoroutine(WaitAndMove(delayTime));


        levelManager = FindObjectOfType<LevelManager>();





    }                                               //END START

    // Update is called once per frame
    void Update()
    {
        currentPos = gameObject.transform.position;
        AnimationStateMech();

        MovePlatform();

        Debug.Log(currentPos);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            transform.position = Vector3.Lerp(currentPos, posA, 6.28f * 0.05f * Time.time);          // MID ONE IS SPEED


        }// END TOGGLE TO TEST HIT ANIMATIONS

    }                                               // END UPDATE



    void AnimationSpinEndedGoBack()
    {
        willSpin = false;
        moveBack = true;
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }


    void AnimationStateMech()
    {
        anim.SetBool("Reached end SPIN", willSpin);
        anim.SetBool("Going Back MOVE BACK", moveBack);
        anim.SetBool("At Start MOVE RIGHT", moveRight);
    }











    void MovePlatform()
    {


        if (currentPos == posA)
        {
            Debug.Log("PLAT AT START");
            moveBack = false;
            willSpin = false;
            moveRight = true;
        }

        if (moveRight)
        {
            Debug.Log("moving right");
            transform.position = Vector3.Lerp(posA, posB, 6.28f * 0.05f * Time.time);          // MID ONE IS SPEED
        }
        
        
            //transform.position = Vector3.Lerp(currentPos, posA, 6.28f * 0.005f * Time.time);
        

        if (currentPos == posB)
        {
            moveRight = false;
            Debug.Log("PLAT AT END");

            willSpin = true;
            moveBack = false;
            //TURN ON THE ANIMATION OF SPIN


        }


        if (moveBack)
        {

            transform.position = Vector3.Lerp(posB, posA, 6.28f * 0.005f * Time.time);


            //   transform.position = Vector3.Lerp(posB, posA, 6.28f * 0.05f * Time.time);
            //  transform.position = Vector3.Lerp(posA, posB, 6.28f * 0.05f * Time.time);          // MID ONE IS SPEED
        }









    }











    void OnTriggerEnter2D(Collider2D other)
    {

        if (other == KillTrigger)
        {
            Debug.Log("PLAYER COLLIDED WITH KILL TRIGGER IN SPINNY");
            if (other.tag == "Player")
            {

            }// end if player
        }//end if killtrigger

    }




    /*
IEnumerator WaitAndMove(float delayTime)
{
    yield return new WaitForSeconds(delayTime); // start at time X
    float startTime = Time.time; // Time.time contains current frame time, so remember starting point
    while (Time.time - startTime <= 1)
    { // until one second passed
        transform.position = Vector3.Lerp(posA, posB, Time.time - startTime); // lerp from A to B in one second
        yield return 1; // wait for next frame
        transform.position = Vector3.Lerp(posB, posA, Time.time - startTime); // lerp from A to B in one second
    }
}
        */











}                                                   // END ALL
