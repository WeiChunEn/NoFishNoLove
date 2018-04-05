using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class End_Time : MonoBehaviour
{
    public Slider _gTimeSlider;
    [SerializeField]
    private float _fTime;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        _gTimeSlider.value = _fTime;
        _fTime -= 1.0f * Time.deltaTime;
	}
}
