using UnityEngine;
using System.Collections;

public class SwordHurtEnemy : MonoBehaviour
{

    private EdgeCollider2D edge;
    private SpriteRenderer render;
    public int damageToGive;
    private MegaCloud cloud;
    // Use this for initialization
    void Start()
    {
        edge = GetComponent<EdgeCollider2D>();
        render = GetComponent<SpriteRenderer>();
        cloud = FindObjectOfType<MegaCloud>();
        turnOff();

        if (cloud.inFireLevel)
        {
            damageToGive = damageToGive / 2;
        }
        if (cloud.inWaterLevel)
        {
            damageToGive = damageToGive * 2;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") // DOESNT MATTER ABOUT y FIX
        {
            //    Destroy(other.gameObject);
            other.GetComponent<EnemyHealthMid>().giveDamage(damageToGive);

        }
    }

    public void turnOn()
    {
        render.enabled = true;
        edge.enabled = false;
    }

    public void turnOff()
    {
        edge.enabled = false;
        render.enabled = false;
    }

    public void swordHit()
    {
         edge.enabled = true;
        StartCoroutine("edgeEnabler");
    }
    IEnumerator edgeEnabler()
    {
        yield return new WaitForSeconds(2);
        edge.enabled = false;
    }

}