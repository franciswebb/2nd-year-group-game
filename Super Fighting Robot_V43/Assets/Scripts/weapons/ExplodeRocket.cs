using UnityEngine;
using System.Collections;

public class ExplodeRocket : MonoBehaviour {


    public int damageToGive, explodeDelay;

    private MegaCloud cloud;

    // Use this for initialization
    void Start () {

        cloud = FindObjectOfType<MegaCloud>();
        if (cloud.inWaterLevel)
        {
            damageToGive = damageToGive / 2;
        }
        if (cloud.inWoodLevel)
        {
            damageToGive = damageToGive * 2;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)  // FIX
    // other here is a variable that is then used in the if statements
    {

        if (other.tag == "Bullets")
        {

        }
        StartCoroutine("explode");





        if (other.tag == "Enemy") // DOESNT MATTER ABOUT y FIX
        {
            //    Destroy(other.gameObject);

            other.GetComponent<EnemyHealthMid>().giveDamage(damageToGive);
            Debug.Log(damageToGive);

            StartCoroutine("explode");

        }







    } // END on trigger


    public IEnumerator explode()
    {
        

        yield return new WaitForSeconds(explodeDelay);
        Destroy(this.gameObject);


    }

}
