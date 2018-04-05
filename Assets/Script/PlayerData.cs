using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerKeys
    {
        public KeyCode Up;
        public KeyCode Down;
        public KeyCode Left;
        public KeyCode Right;
    }
    public PlayerKeys playerKeys;
    public float speed;
    public float hookSpeed;
    public float hookUpSpeed;
    public float hookUpCd;
    public int score;
    public enum PlayerState { normal, poison, magnet, backmagnet }
    public float poisonCD, magnetCD,backmagnetCD;
    public PlayerState playerState;
    public int index;
    public event System.EventHandler MangetEvent;
    public GameObject _gRope;
    public float looseCD;
    public float comboTime;
     public pointBar bar;
    public Player_Anime Anime;
    public CameraShake Shake;
    //public GameObject P1_Win, P2_Win;

    public int _iNow;
    // Use this for initialization
    void Awake()
    {
        playerState = PlayerState.normal;
    }
     void Start()
    {
        _iNow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(playerState ==PlayerState.normal)
        {
            _iNow = 0;
        }*/
    }
    public void SetPoision()
    {
        _iNow = 3;
        playerState = PlayerState.poison;
        Anime._bPosioning = true;
        StartCoroutine(poisonTimer());
        Shake.GetComponent<CameraShake>().shakeDuration = 2.0f; 
    }
    IEnumerator poisonTimer()
    {
        yield return new WaitForSeconds(poisonCD);
        _iNow = 0;
        playerState = PlayerState.normal;
        Anime._bPosioning = false;
        Anime._bIdling = true;

    }
    public void SetMagnet()
    {

        playerState = PlayerState.magnet;
        _iNow = 2;
        StartCoroutine(magTimer());
        for (int i = 1; i < _gRope.GetComponent<Rope>().links; i++)
        {
            _gRope.transform.GetChild(i).GetComponent<CircleCollider2D>().radius = 4.0f;
        }

        //_gRope.GetComponentInChildren<CircleCollider2D>().radius = 4.0f;

        //TODO:


    }
    IEnumerator magTimer()
    {
        yield return new WaitForSeconds(magnetCD);
        playerState = PlayerState.normal;
        _iNow = 0;
        for (int i = 1; i < _gRope.GetComponent<Rope>().links; i++)
        {
            _gRope.transform.GetChild(i).GetComponent<CircleCollider2D>().radius = 0.18f;
        }

    }
    public void BackMagnet()
    {

        playerState = PlayerState.backmagnet;
        _iNow = 1;
        StartCoroutine(bacmagTimer());
        for (int i = 1; i < _gRope.GetComponent<Rope>().links+1; i++)
        {
            _gRope.transform.GetChild(i).GetComponent<CatchFish>()._bCatch = false;
        }

        //_gRope.GetComponentInChildren<CircleCollider2D>().radius = 4.0f;

        //TODO:


    }
    IEnumerator bacmagTimer()
    {
        yield return new WaitForSeconds(backmagnetCD);
        _iNow = 0;
        playerState = PlayerState.normal;
        for (int i = 1; i < _gRope.GetComponent<Rope>().links+1; i++)
        {
            _gRope.transform.GetChild(i).GetComponent<CatchFish>()._bCatch = true;
        }

    }


}
