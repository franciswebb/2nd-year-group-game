using UnityEngine;
using System.Collections;

public class MusicMan : MonoBehaviour
{
    private WaterPhysics waterPhysicsScript;
    private float clipTimeAtEnter;
    private AudioManager theAM;
    public AudioClip normalTrack,waterTrack, bossMusic;

    private BossMusicSwitch bossMusicScript;

    // Use this for initialization
    void Start()
    {
        waterPhysicsScript = GetComponent<WaterPhysics>();
        theAM = FindObjectOfType<AudioManager>();
        bossMusicScript = FindObjectOfType<BossMusicSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterPhysicsScript.isInWater)
        {
            //take time of normal clip change clip to muffled set time to time var
            clipTimeAtEnter = theAM.BGM.time;
            theAM.ChangeBGM(waterTrack);
            theAM.BGM.time = clipTimeAtEnter;
        }
        else
        {
            clipTimeAtEnter = theAM.BGM.time;
            theAM.ChangeBGM(normalTrack);
            theAM.BGM.time = clipTimeAtEnter;

        }
        if (bossMusicScript.inBossRoom == true)
        {
            theAM.ChangeBGM(bossMusic);
        }

    }

   
      
}
