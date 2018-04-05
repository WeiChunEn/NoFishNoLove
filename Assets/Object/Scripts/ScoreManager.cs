using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {
   // public static ScoreManager _scoreManager;
    public Slider p1Slider;
    public Slider p2Slider;
    public GameObject p1, p2;
    //public GameObject P1_Win;
    //public GameObject P2_Win;
    // Use this for initialization
    void Awake () {
     //   if (_scoreManager == null) _scoreManager = new ScoreManager();
   //    FindObjectsOfType<Che> Clicked += this.OnScoreChange;

    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
  

    public void OnScoreChange() {
        p1Slider.value = p1.GetComponent<PlayerData>().score;
        if (p1Slider.value > 100)
        {
            p1Slider.value = 100;
            
           // P1_Win.SetActive(true);
            
        }
        p2Slider.value = p2.GetComponent<PlayerData>().score;
        if (p2Slider.value > 100)
        {
            p2Slider.value = 100;
           // P2_Win.SetActive(true);
        }
    }
}
