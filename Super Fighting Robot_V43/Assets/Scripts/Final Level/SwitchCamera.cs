using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera, cinimaticCamera;
    public bool startBool = false, endAnimBool = false;
    private Animator anim;
    private Player player;


    public GameObject[] hidGround;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = FindObjectOfType<Player>();



        //        int count=13;
        //       for (int i=0; >=count; i++)
        //      {
        //     hidGround[i].GetComponent<Renderer>().enabled = false;
        //        }

        hidGround[0].GetComponent<Renderer>().enabled = false;
        hidGround[1].GetComponent<Renderer>().enabled = false;
        hidGround[2].GetComponent<Renderer>().enabled = false;
        hidGround[3].GetComponent<Renderer>().enabled = false;
        hidGround[4].GetComponent<Renderer>().enabled = false;
        hidGround[5].GetComponent<Renderer>().enabled = false;
        hidGround[6].GetComponent<Renderer>().enabled = false;
        hidGround[7].GetComponent<Renderer>().enabled = false;
        hidGround[8].GetComponent<Renderer>().enabled = false;
        hidGround[9].GetComponent<Renderer>().enabled = false;
        hidGround[10].GetComponent<Renderer>().enabled = false;
        hidGround[11].GetComponent<Renderer>().enabled = false;
   //     hidGround[12].GetComponent<Renderer>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Start", startBool);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            player.enabled = false;
            mainCamera.enabled = false;
            cinimaticCamera.enabled = true;
            startBool = true;


            StartCoroutine("AnimWait");


        }
    }








    public IEnumerator AnimWait()
    {
        // GetComponent<Animation>().Play("Whilys Castle Cinimatic");
        startBool = true;
        yield return new WaitForSeconds(4);

        startBool = false;
        cinimaticCamera.enabled = false;
        mainCamera.enabled = true;
        player.enabled = true;
        endAnimBool = true;




        hidGround[0].GetComponent<Renderer>().enabled = true;
        hidGround[1].GetComponent<Renderer>().enabled = true;
        hidGround[2].GetComponent<Renderer>().enabled = true;
        hidGround[3].GetComponent<Renderer>().enabled = true;
        hidGround[4].GetComponent<Renderer>().enabled = true;
        hidGround[5].GetComponent<Renderer>().enabled = true;
        hidGround[6].GetComponent<Renderer>().enabled = true;
        hidGround[7].GetComponent<Renderer>().enabled = true;
        hidGround[8].GetComponent<Renderer>().enabled = true;
        hidGround[9].GetComponent<Renderer>().enabled = true;
        hidGround[10].GetComponent<Renderer>().enabled = true;
        hidGround[11].GetComponent<Renderer>().enabled = true;
    //    hidGround[12].GetComponent<Renderer>().enabled = true;

    }





}
