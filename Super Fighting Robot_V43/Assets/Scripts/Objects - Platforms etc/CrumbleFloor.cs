using UnityEngine;
using System.Collections;

public class CrumbleFloor : MonoBehaviour
{
    public float delayTime = 0.5f;

    #region Animator
    private Animator anim;
    private bool fall=false;
    #endregion


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Fall", fall);

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("hitDelayCo");

        }
        return;

    }





    public IEnumerator hitDelayCo()
    {

        yield return new WaitForSeconds(delayTime);
        fall = true;

    }




    public void FallReset()
    {
        fall = false;
    }





}
