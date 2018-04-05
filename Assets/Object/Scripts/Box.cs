using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public GameObject player1, player2;
    //public Player_Anime AnimeP1, AnimeP2;

    //2種效果
    //讓別人昏迷
    //磁鐵
    //其他
	// Use this for initialization
	void Start ()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
