using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour {
    public bool hasFish;
    Collider2D _col;
    bool notLoose;
    public bool _bCatch;
    // Use this for initialization
    void Start() {
        hasFish = false;
        notLoose = true;
        _bCatch = true;
    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if((col.tag == "Fish" || col.tag == "Jellyfish" || col.tag =="Box") && col.GetComponent<SpringJoint2D>()==null && !hasFish  && notLoose && _bCatch ==true )//TODO:add plauer state

        {
            _col = col;
            SpringJoint2D joint = col.gameObject.AddComponent<SpringJoint2D>();        
            joint.autoConfigureDistance = false;
            joint.distance = 0;
            joint.connectedBody = this.gameObject.GetComponent<Rigidbody2D>(); 
            joint.anchor = Vector2.zero;
            joint.connectedAnchor = new Vector2(0f, 0f);
            joint.frequency = 0.0f;
            joint.dampingRatio = 1;
            hasFish = true;
            col.GetComponent<Fish_Move>().enabled = false;
            GetComponentInParent<Player_test>().fishNum++;
            col.GetComponent<fish_data>().playerIndex = GetComponentInParent<PlayerData>().index;
        }

    }
    public void SetFishLoose()
    {
        if (_col != null)
        {
            Destroy(_col.gameObject.GetComponent<SpringJoint2D>());
            Destroy(_col.gameObject.GetComponent<Rigidbody2D>());
            _col.GetComponent<Fish_Move>().enabled = true;
            GetComponentInParent<Player_test>().fishNum--;
            _col.GetComponent<fish_data>().playerIndex = 0;
            hasFish = false;
            notLoose = false;
            StartCoroutine(notLooseTime());
            _col = null;
        }


    }
    IEnumerator notLooseTime()
    {
        yield return new WaitForSeconds(GetComponentInParent<PlayerData>().looseCD);
        notLoose = true;
    }
}
