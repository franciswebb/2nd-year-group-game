using UnityEngine;
using System.Collections;

public class RandomFromRange : MonoBehaviour
{
    Random rnd = new Random();
    public int raInt = 0, min = 0, max = 3;
    //public float 

    // Use this for initialization
    void Start()
    {
        #region Picks Rando from min - max then +1 as to allow for max 
        // 
        /* 
         */
        raInt = Random.Range(min, max);
        raInt++;
        #endregion
        //  Instantiate(megaShot, firePoint.position, firePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(raInt + " IS THE RANDO INT");
        if (raInt == 1)
        {
            Debug.Log("11111111111111111111111111111RANDO1111111111111111111111111111");
        }
        if (raInt == 2)
        {
            Debug.Log("22222222222222222222222222222RANDO2222222222222222222222222222222222222");
        }
        if (raInt == 3)
        {
            Debug.Log("3333333333333333333333333333333333RANDO33333333333333333333333333333333");
        }

    }





}
