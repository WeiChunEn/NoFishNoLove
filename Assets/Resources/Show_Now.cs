using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Now : MonoBehaviour
{
    public Player_Anime Anime;
    public PlayerData playerData;
    [SerializeField]
    private Sprite[] _gNow_State;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _gNow_State[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerData._iNow == 0  )
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _gNow_State[0];
        }
        else if(playerData._iNow==1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _gNow_State[1];
        }
        else if (playerData._iNow == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _gNow_State[2];
        }
        else if (playerData._iNow == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _gNow_State[3];
        }
    }
}
