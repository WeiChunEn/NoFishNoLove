using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fish_Score : MonoBehaviour
{
    /*[SerializeField]
    private bool _bCatchFish;*/
    [SerializeField]
    private float _fScore;

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Fish")
        {

        }
    }
}   
