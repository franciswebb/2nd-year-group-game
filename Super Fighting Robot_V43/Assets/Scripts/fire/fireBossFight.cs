using UnityEngine;
using System.Collections;

public class fireBossFight : MonoBehaviour {

    public bool firstFight = false, secondFight = false, firstFightFinished = false, SecondFightFinished = false, reset = false, inRange = false;
    public EnemyHealthMid bossHealth;
    private Animator anim;
    private firebossLava lava;
    private HealthManager player;
    private int health;
    private CheckPlayerInRange range;
   
    // Use this for initialization
    void Start () {

        range = GetComponent<CheckPlayerInRange>();
        player = FindObjectOfType<HealthManager>();
        lava = FindObjectOfType<firebossLava>();
        anim = gameObject.GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {

        if(bossHealth.enemyHealth <= 0)
        {

        }


        anim.SetBool("firstFight", firstFight);
        anim.SetBool("firstFightFinished", firstFightFinished);
        anim.SetBool("SecondFightFinished", SecondFightFinished);
        anim.SetBool("secondFight", secondFight);
        anim.SetBool("reset", reset);
        anim.SetBool("inRange", inRange);


        if (player.isDead == true)
        {
            reset = true;
          
        }

        if(range.playerInRange == true)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
     


        if (firstFightFinished == false)
        {
            if (bossHealth.enemyHealth < 75 && firstFight == false)
            {
                firstFight = true;
                lava.start1();
            }
        }

        if (SecondFightFinished == false && firstFightFinished == true && secondFight == false)
        {
            if (bossHealth.enemyHealth < 40)
            {
                secondFight = true;
                lava.start2();
            }
        }

    }
 
    void firstFinish()
    {
        firstFightFinished = true;
    }
    void secondFinish()
    {
        SecondFightFinished = true;
    }
    void resetscene()
    {
        
            reset = false;
        
    }
}
