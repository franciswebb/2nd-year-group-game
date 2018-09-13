using UnityEngine;
using System.Collections;

public class PlayerInBossRoomWood : MonoBehaviour
{
    public GameObject TutaBoss;

    public AudioClip bossMusic;
    private AudioManager theAM;

    // Use this for initialization
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }







    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (bossMusic != null)
            {
                theAM.ChangeBGM(bossMusic);
            }

            TutaBoss.GetComponent<WoodsBoss>().playerInBossRoom = true;
            //          GetComponent<TUTBoss>().playerInBossRoom = true;
            Debug.Log("PLAYER IN BOSS ROOM! PLAYER IN BOSS ROOM! PLAYER IN BOSS ROOM! PLAYER IN BOSS ROOM! PLAYER IN BOSS ROOM! PLAYER IN BOSS ROOM! PLAYER IN BOSS ROOM! ");

        }
        return;

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TutaBoss.GetComponent<WoodsBoss>().playerInBossRoom = false;
        }
        
    }
}
