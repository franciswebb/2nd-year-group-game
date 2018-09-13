using UnityEngine;
using System.Collections;

public class ChrisDamageContact : MonoBehaviour
{


    public float moveSpeed;
    public bool moveRight = false;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool atEdge;
    public Transform edgeCheck;

    public bool canWalk;
    private Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


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

    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Block")
        {

            Destroy(this.gameObject);

        }
    }

    }//                                                                         END ALL
