using UnityEngine;
using System.Collections;

public class MegaCloud : MonoBehaviour
{

    public bool finalUnlocked_Cloud = false, tutFinished_Cloud = false, fireFinished_Cloud = false, waterFinished_Cloud = false, woodFinished_Cloud = false;
    public bool inTutLevel=false, inFireLevel = false, inWoodLevel = false, inWaterLevel = false, inFinalLevel = false;
    public int lives_Cloud = 3, energyTank_Cloud = 0;
    
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //  Platform Player cloud check menu controller bARRELmON distance script

    // Update is called once per frame
    void Update()
    {

    }
}
