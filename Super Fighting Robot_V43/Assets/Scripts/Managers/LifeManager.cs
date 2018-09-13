using UnityEngine;
using UnityEngine.UI;


public class LifeManager : MonoBehaviour
{

    public int startingLives;
    public Text str_startingLives;
    private int lifeCounter;

    
    private int livesToShow;

    // Use this for initialization
    void Start()
    {
        str_startingLives.text = startingLives.ToString();



        lifeCounter = startingLives;

    }

    // Update is called once per frame
    void Update()
    {

       


    }

    public void GiveLife()
    {
        startingLives++;

        str_startingLives.text = startingLives.ToString();
    }
    public void TakeLife()
    {
        startingLives--;
        str_startingLives.text = startingLives.ToString();
    }
}