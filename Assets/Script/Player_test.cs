using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_test : MonoBehaviour {
    public Player_Anime anime;
    PlayerData _data;
    Rigidbody2D rig;
    public GameObject hook;
    Rigidbody2D hookRig;
    bool canUp;
    public float MaxLength, MinLength;
    public int fishNum;
    public GameObject ropeRoot;
    public Transform rootPos_up, rootPos_down;
    public bool looseFish;
    float looseT;
    int looseCombo;
    // Use this for initialization
    void Start() {
        _data = GetComponent<PlayerData>();
        rig = GetComponent<Rigidbody2D>();
        hookRig = hook.GetComponent<Rigidbody2D>();
        canUp = true;     
        fishNum = 0;
        looseFish = false;
        looseT = 0;
        looseCombo = 0;
    }

    // Update is called once per frame
    void Update() {
       if(_data.playerState != PlayerData.PlayerState.poison) control();
        //Debug.Log("hook:" + hookRig.velocity.y);
    }

    IEnumerator hookCD() {
        yield return new WaitForSeconds(_data.hookUpCd);
        canUp = true;
        yield return null;
    }

    void control() {
        if (Input.GetKeyDown(_data.playerKeys.Up))//魚鉤往上彈
        {
            
            
            if (canUp) {
                anime._bFishing = true;
                anime._bIdling = false;
                anime._bPosioning = false;
                canUp = false;
                StartCoroutine(hookCD());
              //  Debug.Log("123:"+ rig.velocity.x * Time.deltaTime);
                Vector2 v;
                v.x = hookRig.velocity.x * 10.0f* Time.deltaTime;
                v.y = (_data.hookUpSpeed  + fishNum * fishNum * 0.1f) * Time.deltaTime;//test
                Debug.Log(v);
                hookRig.AddForce(v, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(_data.playerKeys.Up))//魚鉤往上
        {
            
            if (ropeRoot.transform.position.y < rootPos_up.position.y) ropeRoot.transform.position += new Vector3(0, +_data.hookSpeed * Time.deltaTime, 0);
            HingeJoint2D[] links = GetComponentsInChildren<HingeJoint2D>();
            foreach (HingeJoint2D link in links)
            {
                
                if (Mathf.Abs(link.connectedAnchor.y) > MinLength / links.Length) link.connectedAnchor += new Vector2(0, _data.hookSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(_data.playerKeys.Down))//往下
        {
           
            if (ropeRoot.transform.position.y > rootPos_down.position.y) ropeRoot.transform.position += new Vector3(0, -_data.hookSpeed *Time.deltaTime, 0);
            HingeJoint2D[] links = GetComponentsInChildren<HingeJoint2D>();
            foreach (HingeJoint2D link in links)
            {
               if(Mathf.Abs(link.connectedAnchor.y) < MaxLength / links.Length) link.connectedAnchor += new Vector2(0, -_data.hookSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(_data.playerKeys.Down))
        {
            looseCombo++;
            InvokeRepeating("looseTime", 0, Time.deltaTime);
           LooseFish();
            Debug.Log("combo" + looseCombo);
        }
    
    }
    void LooseFish()
    {
        
       
        if (looseFish && looseCombo == 2)
        {
           // looseFish = false;
            if (hook.transform.position.y < -0.2f)//在海裡才能放
            {
                Debug.Log("loose");
                CatchFish[] links = GetComponentsInChildren<CatchFish>();
                foreach (CatchFish _link in links)
                {
                    _link.SetFishLoose();
                }
                looseFish = true;
                looseCombo = 0;
            }
            
            
            CancelInvoke("looseTime");

        }

    }
    void looseTime()
    {
        if (looseT > _data.comboTime)
        {
            looseFish = false;
            looseT = 0;
            looseCombo = 0;
            CancelInvoke("looseTime");
        }
        looseT += Time.deltaTime;
       
        looseFish = true;
        
    }
    
}
