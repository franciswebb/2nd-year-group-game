using UnityEngine;
using System.Collections;

public class bosskill : MonoBehaviour {
    public GameObject boss;
    private GameObject destroyMe;
    // Use this for initialization
    void Start () {
        destroyMe = boss;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            Destroy(destroyMe);

        }
    }
}
