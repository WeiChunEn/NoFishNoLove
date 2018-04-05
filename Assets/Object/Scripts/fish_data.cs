using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_data : MonoBehaviour
{
    public int score;
    public int playerIndex;
    public int type;
    [SerializeField]
    private int _iRnd;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(gameObject.tag =="Box")
        {
            _iRnd = Random.Range(1, 4);
        }
        type = _iRnd;
	}
}
