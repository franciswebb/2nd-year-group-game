using UnityEngine;
using System.Collections;

public class BossFightRoom : MonoBehaviour {

    public AudioClip newTrack;
    private AudioManager theAM;
    public AudioClip victoryMusic;
    public EnemyHealthMid bossHealth;
    private Player player;
    private LevelLoaderCloudCheck levelLoadering;
    private AudioClip previousTrack;


    void Start() {
        theAM = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<Player>();
        levelLoadering = FindObjectOfType<LevelLoaderCloudCheck>();
        previousTrack = theAM.BGM.clip;

    }

    // Update is called once per frame
    void Update() {

        if (bossHealth.enemyHealth < 1)
        {
            player.enabled = false;
            StartCoroutine("Victory");
        }
            Debug.Log(previousTrack);
    }




      public IEnumerator Victory()
     {
        theAM.GetComponent<AudioSource>().pitch = 1f;
        theAM.GetComponent<AudioSource>().loop = false;
        theAM.ChangeBGM(victoryMusic);
    
        yield return new WaitForSeconds(8);

        levelLoadering.LoadLevel();



     }





void OnTriggerEnter2D(Collider2D other)  
    {
    
        if (other.tag == "Player")
        {
            theAM.ChangeBGM(newTrack);
        }
    }

    void OnTriggerExit2D(Collider2D other)

    {
        if (other.tag == "Player")
        {
            previousTrack = theAM.BGM.clip;

            Delay();
        }


    }



    public IEnumerator Delay()
    {

        yield return new WaitForSeconds(2);
        theAM.ChangeBGM(previousTrack);

    }



}
