using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Put_Fish : MonoBehaviour
{
    public GameObject[] Fish;
    public int _iAllKindFish = 0;
    [SerializeField]
    private float[] _fProbility;
    [SerializeField]
    private bool _bOpen;
    [SerializeField]
    private float _fStartTime = 0.0f;
    [SerializeField]
    private float _fAppearTime = 5.0f;
    [SerializeField]
    private float _fRndX = 0.0f;
    [SerializeField]
    private float _fRndY = 0.0f;
    [SerializeField]
    private int _iRnd;
    [SerializeField]
    private int _iNum;
    [SerializeField]
    private int _iFish_Num;

    //public GameObject _gGame;
    void Start()
    {
        _iAllKindFish = Fish.Length;

    }

    public void 
        Update()
    {
        _fStartTime += Time.deltaTime;
        if (_fStartTime >= _fAppearTime)
        {
            _fStartTime = 0.0f;
            if (_iFish_Num < 30)
            {
                appear();
            }

        }
    }
    void appear()
    {

        _iNum = Random.Range(1, 5);
        for (int i = 0; i < _iNum; i++)
        {
            print(1);

            _fRndX = Random.Range(-5.0f, 5.0f);
            _fRndY = Random.Range(-3.0f, 4.0f);
            _iRnd = Random.Range(0, _iAllKindFish);
            if (Random.Range(0.0f, 1.0f) > _fProbility[_iRnd])
            {
                GameObject _fish;
                _fish = Instantiate(Fish[_iRnd], new Vector2(_fRndX, _fRndY), Fish[_iRnd].transform.rotation);
                _fish.transform.parent = gameObject.transform;
                _iFish_Num++;
            }
            else
            {
                i--;
            }
        }
    }
    public void FishNumChange(int i) {
        _iFish_Num += i;
    }
}
