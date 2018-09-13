using UnityEngine;
using System.Collections;

public class Item1Float : MonoBehaviour
{

    public bool goUp = true;

    #region Animator
    private Animator anim;
    #endregion


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("GoUp", goUp);

    }
    void Update()
    {

    }
}