using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour

{
    public AudioSource BGM;

//    public string[] audioName;
  //  public AudioClip[] audioClip;
    //public bool clipFound;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ChangeBGM(AudioClip music)
    {

        if (BGM.clip.name == music.name)
        {
            return;//ends does nothing
        }
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }






    // is clip playing is so return do nothing . is clip finished end intro play looping music.  is clip playing if player in zone play next clip if not keep checking for when can


}
