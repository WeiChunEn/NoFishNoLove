using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anime : MonoBehaviour
{
    private Animator anim;
    public bool _bPosioning;
    public bool _bIdling;
    public bool _bFishing;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Poison", _bPosioning);
        anim.SetBool("Idle", _bIdling);
        anim.SetBool("Fish", _bFishing);
        

    }
}
