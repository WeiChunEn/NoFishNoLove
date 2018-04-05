using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFish : MonoBehaviour {
    int i_checkFish;
    bool canAddScore;
    float checkFishTimer;
    PlayerData _player;
    fish_data _fdata;
    public GameObject disani;
    // Use this for initialization
    void Start () {
        i_checkFish = 1;
        canAddScore = false;
        checkFishTimer = 0;
        _fdata = GetComponent<fish_data>();
    }
	
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i = 0;

        if (collision.name == "Score_Area1") {
            i = 1;
            _player = collision.GetComponentInParent<PlayerData>();
        }
        else if (collision.name == "Score_Area2")
        {
            i = -2;
            _player = collision.GetComponentInParent<PlayerData>();
        }
        CheckFish(i);
    }
    public void CheckFish(int i)
    {
        InvokeRepeating("checkFishtimer", 0, Time.deltaTime);
        i_checkFish += i;
       // Debug.Log(i_checkFish);
        if (i_checkFish < 0 || i_checkFish > 2)
        {//reset
            i_checkFish = 1;
        }
        else if (i_checkFish == 0 && canAddScore)
        {
            if (_fdata.playerIndex == _player.GetComponent<PlayerData>().index)
            {
               
                _player.score += _fdata.score;


                //FindObjectOfType<ScoreManager>().OnScoreChange();
                _player.bar.SetScore(_player.score);
                if (GetComponent<fish_data>().score == 1)//special effect
                {
                    switch (GetComponent<fish_data>().type) {
                        case 0://jelly
                            _player.GetComponent<PlayerData>().SetPoision();
                            break;
                        case 1://other player poison
                          
                            if (_player.GetComponent<PlayerData>().index == 1)
                            {
                                GetComponent<Box>().player2.GetComponent<PlayerData>().SetPoision();
                                //GetComponent<PlayerData>().Player_date.SetPoision();
                            }
                            else GetComponent<Box>().player1.GetComponent<PlayerData>().SetPoision();
                          
                            break;
                        case 2://manget
                            _player.GetComponent<PlayerData>().SetMagnet();
                        
                            break;
                        case 3://反manget
                            if (_player.GetComponent<PlayerData>().index == 1)
                            {
                                GetComponent<Box>().player2.GetComponent<PlayerData>().BackMagnet();
                            }
                            else GetComponent<Box>().player1.GetComponent<PlayerData>().BackMagnet();
                            //GetComponent<PlayerData>().Player_date.BackMagnet();
                            break;
                    } 
                }
                _player.GetComponent<Player_test>().fishNum--;
                FindObjectOfType<Put_Fish>().FishNumChange(-1);
                GetComponent<SpringJoint2D>().connectedBody.GetComponent<CatchFish>().hasFish = false;
                Instantiate(disani, _player.transform.position, _player.transform.rotation);               
                Destroy(this.gameObject);
            }
        }
        
    }
    void checkFishtimer()
    {
        canAddScore = true;
        checkFishTimer += Time.deltaTime;
        if (checkFishTimer > 1.0f)
        {
            canAddScore = false;
            i_checkFish = 1;
            checkFishTimer = 0;
            CancelInvoke("checkFishtimer");
        }
    }
}
