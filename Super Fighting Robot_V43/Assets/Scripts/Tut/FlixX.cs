using UnityEngine;
using System.Collections;

public class FlixX : MonoBehaviour {
    private CheckPlayerInRange playerRange;

    // Use this for initialization
    void Start () {
        playerRange = GetComponent<CheckPlayerInRange>();

    }

    // Update is called once per frame
    void Update () {
        if (playerRange.playerInRange)
        {
            if (playerRange.playerLeft==false)
            {
                gameObject.transform.localScale += new Vector3(-1, 1, 1);
            }

        }

    }
}
