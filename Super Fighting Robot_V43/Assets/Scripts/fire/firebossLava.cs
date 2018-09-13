using UnityEngine;
using System.Collections;

public class firebossLava : MonoBehaviour {

    public Transform lavaPoint1, lavaPoint2, lavaPoint3, lavaPoint4, lavaPoint5, lavaPoint6;
    public GameObject lava;
    public float lavadelayTime;
    public fireBossFight bossFight;
    // Use this for initialization
    void Start () {


        bossFight = FindObjectOfType<fireBossFight>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void destroy()
    {
        Destroy(this.gameObject);
    }

    public void start1()
    {
       
        StartCoroutine("lavaDelay");
             

    }

    public void start2()
    {
        StartCoroutine("startDelay");
        
    }

    IEnumerator lavaDelay()
    {

        yield return new WaitForSeconds(lavadelayTime+2);
         Instantiate(lava, lavaPoint1.position, lavaPoint1.rotation);
        StartCoroutine("lavaDelay1");

    }

    IEnumerator lavaDelay1()
    {
             
        yield return new WaitForSeconds(lavadelayTime);
        Instantiate(lava, lavaPoint2.position, lavaPoint2.rotation);
        StartCoroutine("lavaDelay2");

    }

    IEnumerator lavaDelay2()
    {

        yield return new WaitForSeconds(lavadelayTime);
        Instantiate(lava, lavaPoint3.position, lavaPoint3.rotation);
 

    }
    
    IEnumerator lavaDelay3()
    {

        yield return new WaitForSeconds(lavadelayTime);
        Instantiate(lava, lavaPoint6.position, lavaPoint6.rotation);
        Instantiate(lava, lavaPoint4.position, lavaPoint4.rotation);
        StartCoroutine("lavaDelay4");

    }
    IEnumerator lavaDelay4()
    {

        yield return new WaitForSeconds(lavadelayTime);
        Instantiate(lava, lavaPoint2.position, lavaPoint2.rotation);
        Instantiate(lava, lavaPoint5.position, lavaPoint5.rotation);


    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(lavadelayTime);
        Instantiate(lava, lavaPoint5.position, lavaPoint5.rotation);
        Instantiate(lava, lavaPoint3.position, lavaPoint3.rotation);
        StartCoroutine("lavaDelay3");


    }

    

}
