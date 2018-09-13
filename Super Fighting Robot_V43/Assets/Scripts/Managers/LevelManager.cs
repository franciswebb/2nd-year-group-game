using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private string gameOver;
    public Renderer rend;

    private AudioManager theAM;

    public HealthManager healthManager;

    public GameObject currentCheckpoint;

    private Player player;

    public float respawnDelay = 2;

    public GameObject deathParticle;

    private LifeManager lifeManager;


    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
        lifeManager = FindObjectOfType<LifeManager>();
        healthManager = FindObjectOfType<HealthManager>();
        #region Turn off visability

        rend = GetComponent<Renderer>();
        rend.enabled = false;

        #endregion
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    public void RespawnPlayer()
    {
        if (lifeManager.startingLives < 1)
        {
            StartCoroutine("gameover");
        }
        else
        {
            StartCoroutine("RespawnPlayerCo");
        }
    }

    public IEnumerator RespawnPlayerCo()
    {



        player.rb2dPlayer.constraints = RigidbodyConstraints2D.FreezePositionY;


        theAM = FindObjectOfType<AudioManager>();



            Instantiate(deathParticle, player.transform.position, player.transform.rotation);
            player.enabled = false;
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeAll;

            yield return new WaitForSeconds(respawnDelay);
            player.transform.position = currentCheckpoint.transform.position;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.enabled = true;
            player.GetComponent<Animator>().enabled = true;
            player.rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;

            lifeManager.TakeLife();
            theAM.BGM.Play();
            healthManager.FullHealth();
            healthManager.isDead = false;
            
        
    }


    public IEnumerator gameover()
    {

        gameOver = "10 Gaming Over";
        player.DeathSFX.Play();

        Debug.Log("Player Respawn - LevelManager");
        player.enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(3);
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.rb2dPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
        Application.LoadLevelAsync(gameOver);



    }

}
