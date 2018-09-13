using UnityEngine;
using System.Collections;

public class ExplodeRocketOverTime : MonoBehaviour {

    public float lifetime;
    private Rocket rocket;

    // Use this for initialization
    void Start()
    {
        rocket = GetComponent<Rocket>();
    }

    // Update is called once per frame
    void Update()
    {

        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Instantiate(rocket.explodeRocket, rocket.explodePoint.position, rocket.explodePoint.rotation);
            Destroy(gameObject);
        }


    }
}
