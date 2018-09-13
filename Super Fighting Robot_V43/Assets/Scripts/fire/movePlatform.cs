using UnityEngine;
using System.Collections;

public class movePlatform : MonoBehaviour {

    public bool move;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("move", move);
    }
}
