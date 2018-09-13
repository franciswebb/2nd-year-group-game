using System.Collections;
using UnityEngine;

namespace PC2D
{
    public class movingPlatformController : MonoBehaviour
    {
        public float leftRightAmount;
        public float speed;
        public float comebackSpeed;
        public float waitDelay;
        public bool moving = true;

        public BoxCollider2D returnToStart, makeChild;

        private Player player;
        private MovingPlatformMotor2D _mpMotor;
        private GameObject platform;
        private float _startingX;


        // Use this for initialization
        void Start()
        {
            returnToStart = GetComponent<BoxCollider2D>();


            _mpMotor = GetComponent<MovingPlatformMotor2D>();
            _startingX = transform.position.x;
            _mpMotor.velocity = -Vector2.right * speed;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (moving == true)
            {
                if (_mpMotor.velocity.x < 0 && _startingX - transform.position.x >= leftRightAmount)
                {
                    StartCoroutine("waitright");
                    transform.position += Vector3.right * ((_startingX - transform.position.x) - leftRightAmount);
                    _mpMotor.velocity = Vector2.right * speed;
                }
                else if (_mpMotor.velocity.x > 0 && transform.position.x - _startingX >= leftRightAmount)
                {
                    StartCoroutine("waitleft");
                    transform.position += -Vector3.right * ((transform.position.x - _startingX) - leftRightAmount);
                    _mpMotor.velocity = -Vector2.right * (speed * 2);
                }
            }
            else
            {
                _mpMotor.velocity = Vector2.right * (speed / 2000);
            }
        }




        IEnumerator waitright()
        {
            moving = false;
            yield return new WaitForSeconds(waitDelay);
            moving = true;
            _mpMotor.velocity = Vector2.right * speed;


        }

        IEnumerator waitleft()
        {
            moving = false;
            yield return new WaitForSeconds(waitDelay);
            moving = true;
            _mpMotor.velocity = -Vector2.right * comebackSpeed;


        }

    }















}





