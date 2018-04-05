using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointBar : MonoBehaviour {

    float _barScale;
    public Transform barscale;
    float _score;
    public float MaxScore;
    public Transform edgeL, edgeR;
    public GameObject target;
	// Use this for initialization
	void Start () {
        _score = 0;

        _barScale = barscale.transform.localScale.x;

    }
	
	// Update is called once per frame
	void Update () {
        follow();

    }
    public void SetScore(int i) {
        _score = i;
        _score = _score * 0.96f;
        updateScore();
    }
    void updateScore() {
        _barScale = _score / MaxScore;//0~1 ->0~100 0~0.96->0~100
        if (_barScale > 0.96f) _barScale = 0.96f;
        Vector3 _scale = barscale.transform.localScale;
        _scale.x = _barScale;
        barscale.transform.localScale = _scale;
    }
    void follow()
    {

        Vector3 _tar = transform.position;
        Debug.Log("TAR" + target.transform.position);
        _tar.x = target.transform.position.x;
        Debug.Log("tar:" + _tar);
        if(_tar.x > edgeL.position.x && _tar.x < edgeR.position.x)
           transform.position = Vector3.MoveTowards(transform.position, _tar, 5 * Time.deltaTime);

    }
}
