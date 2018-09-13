using UnityEngine;
using System.Collections;

public class PickUpBaddieManager : MonoBehaviour
{
    Random rnd = new Random();
    public int raInt = 0, min = 0, max = 10;
    public int itemMin = 0, itemMax = 100;
    private int ranItemPick = 0, itemPickMin = 0, itemPickMax = 7;
    private int switchIndicator;

    public GameObject lifePickUp, eTankPickUp, bigHealth, smallHealth, bigAmmo, smallAmmo;
    //public float 

    // Use this for initialization
    void Start()
    {

        ranItemPick = Random.Range(itemPickMin, itemPickMax);
        ranItemPick++;

        raInt = Random.Range(min, max);
        raInt++;
        switchIndicator = raInt;



        //6 items
    }

    // Update is called once per frame
    void Update()
    {







    }



    public void PickUpManagement()
    {
        switch (ranItemPick)
        {
            case 1:
                if (Random.Range(min, max) <= 20)
                {
                    Debug.Log("Life PICKUP!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    var pickupDrop = Instantiate(lifePickUp, gameObject.transform.position, Quaternion.identity);
                    /* if (lifePickUp==null) { return; } else { } */
                }
                //health 
                break;
            case 2:
                if (Random.Range(itemMin, itemMax) <= 30)
                {
                    Debug.Log("E Tank PICKUP!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    var pickupDrop = Instantiate(eTankPickUp, gameObject.transform.position, Quaternion.identity);
                }
                break;
            case 3:
                if (Random.Range(itemMin, itemMax) <= 40)
                {
                    Debug.Log("Health Big PICKUP!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    var pickupDrop = Instantiate(bigHealth, gameObject.transform.position, Quaternion.identity);
                }
                break;
            case 4:
                if (Random.Range(itemMin, itemMax) <= 60)
                {
                    Debug.Log("Health Small PICKUP!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    var pickupDrop = Instantiate(smallHealth, gameObject.transform.position, Quaternion.identity);
                }
                break;
            case 5:
                if (Random.Range(itemMin, itemMax) <= 40)
                {
                    Debug.Log("Ammo Big PICKUP!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    var pickupDrop = Instantiate(bigAmmo, gameObject.transform.position, Quaternion.identity);
                }
                break;
            case 6:
                if (Random.Range(itemMin, itemMax) <= 60)
                {
                    var pickupDrop = Instantiate(smallAmmo, gameObject.transform.position, Quaternion.identity);
                    Debug.Log("Ammo Small PICKUP!!!!!!!!!!!!!!!!!!!!!!!!!!");
                }
                break;



            case 7:
                Debug.Log("YOU GET NOTHING GOOD DAY SIR!!!!!!!!!!!!!!Unlucky!!!!!!!!!!!!");

                //Do Nothing
                break;




            default:
                Debug.Log("YOU GET NOTHING GOOD DAY SIR!!!!!!!!!!!!DEFAULT!!!!!!!!!!!!!!");

                break;

        }

    }

}
