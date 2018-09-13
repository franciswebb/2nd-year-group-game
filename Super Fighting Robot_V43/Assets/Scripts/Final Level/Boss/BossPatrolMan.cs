using UnityEngine;
using System.Collections;

public class BossPatrolMan : MonoBehaviour
{


    public float moveSpeed = 4.5f;
    public bool moveRight = false;

    public Transform wallCheck;
    public float wallCheckRadius = 0.1f;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool atEdge;
    public Transform edgeCheck;

    public bool canWalk;
    private float checkXStartPos, currentXPos;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        StartCoroutine("CheckX");
    }

    // Update is called once per frame
    void Update()
    {
        checkXStartPos = transform.position.x;

        if (canWalk)
        {
            if (hittingWall || !atEdge)
            {
                moveRight = !moveRight;
            }
            else
            {
                //Debug.Log("IS IN AIR_ENEMY PATROL");
            }

            if (moveRight)
            {

                transform.localScale = new Vector3(-1f, 1f, 1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }

            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
    }

    public IEnumerator CheckX()
    {
        currentXPos = transform.position.x;
        yield return new WaitForSeconds(0.15f);

        if (currentXPos == checkXStartPos)
        {
            if (moveRight == true)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
        StartCoroutine("CheckX");
    }


}//                                                                         END ALL
