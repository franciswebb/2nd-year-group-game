using UnityEngine;
using System.Collections;

public class SwitchMusicTrigger : MonoBehaviour
{

    public AudioClip newTrack;

    private AudioManager theAM;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (newTrack != null)
            {

                theAM = FindObjectOfType<AudioManager>();
                theAM.ChangeBGM(newTrack);

            }
        }
    }



}
