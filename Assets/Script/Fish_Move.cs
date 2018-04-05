using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Move : MonoBehaviour
{
    /*public Transform start_point;
    public Transform end_point;*/
    public float _fDistance;
    public float _fStart_x;
    public float _fSpeed = 5.0f;
    [SerializeField]
    private float _fFishX;
    [SerializeField]
    private float _fFishY;
    [SerializeField]
    private int flag1;
    [SerializeField]
    private Vector2 _vFirst_Posi;
    [SerializeField]
    private int flag2;
    


    void Start()
    {
        // _fStart_x = gameObject.transform.position.x;
        _vFirst_Posi = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
       // _vBotPosi = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);
    }


    void Update()
    {
        
        _fFishX = gameObject.transform.position.x;
        if (gameObject.tag == "Jellyfish")
        {
            if (gameObject.transform.position.y <= _vFirst_Posi.y+1.0f &&flag2==0)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, _fFishY += Time.deltaTime * 4.0f);
            }
            else if(gameObject.transform.position.y <= _vFirst_Posi.y-1.0f)
            {
                flag2 = 0;
            }
            else if(gameObject.transform.position.y > _vFirst_Posi.y+1.0f || flag2!=0)
            {
                flag2++;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, _fFishY -= Time.deltaTime * 4.0f);
            }
            if (gameObject.transform.position.x <= 13.0f && flag1 == 0)
            {
                
                //tmp = new Vector2(_fFishX += Time.deltaTime * _fSpeed, transform.position.y);
                //gameObject.transform.position = Vector2.Lerp(tmp, _vTopPosi, Time.deltaTime);
                gameObject.transform.position = new Vector2(_fFishX += Time.deltaTime *_fSpeed, gameObject.transform.position.y);
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f); ;
            }
            else if (gameObject.transform.position.x <= -13.0f)
            {
               // print(2);
                flag1 = 0;
            }
            else if (gameObject.transform.position.x > 13.0f || flag1 != 0)
            {
                //tmp = new Vector2(_fFishX += Time.deltaTime * _fSpeed, transform.position.y);
                gameObject.transform.position = new Vector2(_fFishX -= Time.deltaTime * _fSpeed, transform.position.y);
                flag1++;
                gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
               // gameObject.transform.position = Vector2.Lerp(tmp, _vBotPosi, Time.deltaTime);
            }
        }
        else if(gameObject.tag == "Box")
        {

            if (gameObject.transform.position.y <= _vFirst_Posi.y + 0.3f && flag2 == 0)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, _fFishY += Time.deltaTime * 2.0f);
            }
            else if (gameObject.transform.position.y <= _vFirst_Posi.y - 0.3f)
            {
                flag2 = 0;
            }
            else if (gameObject.transform.position.y > _vFirst_Posi.y + 0.3f || flag2 != 0)
            {
                flag2++;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, _fFishY -= Time.deltaTime * 2.0f);
            }
            if (gameObject.transform.position.x <= 13.0f && flag1 == 0)
            {

                //tmp = new Vector2(_fFishX += Time.deltaTime * _fSpeed, transform.position.y);
                //gameObject.transform.position = Vector2.Lerp(tmp, _vTopPosi, Time.deltaTime);
                gameObject.transform.position = new Vector2(_fFishX += Time.deltaTime * _fSpeed, gameObject.transform.position.y);
               // gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f); ;
            }
            else if (gameObject.transform.position.x <= -13.0f)
            {
                //print(2);
                flag1 = 0;
            }
            else if (gameObject.transform.position.x > 13.0f || flag1 != 0)
            {
                //tmp = new Vector2(_fFishX += Time.deltaTime * _fSpeed, transform.position.y);
                gameObject.transform.position = new Vector2(_fFishX -= Time.deltaTime * _fSpeed, transform.position.y);
                flag1++;
                //gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                // gameObject.transform.position = Vector2.Lerp(tmp, _vBotPosi, Time.deltaTime);
            }
        }
        else
        {
            if (gameObject.transform.position.x <= 13.0f && flag1 == 0)
            {
                gameObject.transform.position = new Vector2(_fFishX += Time.deltaTime * _fSpeed, transform.position.y);
                gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f); ;
            }
            else if (gameObject.transform.position.x <= -13.0f)
            {
                //print(2);
                flag1 = 0;
            }
            else if (gameObject.transform.position.x > 13.0f || flag1 != 0)
            {
                gameObject.transform.position = new Vector2(_fFishX -= Time.deltaTime * _fSpeed, transform.position.y);
                flag1++;
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f); ;
            }
        }
        
        
        
        
        /*else if(gameObject.transform.position.x > 5.0f)
        {
            gameObject.transform.position = new Vector2(_fFishX -= Time.deltaTime * _fSpeed, transform.position.y);
        }
        else if (gameObject.transform.position.x >= 5.0f)
        {
            gameObject.transform.position = new Vector2(_fFishX -= Time.deltaTime * _fSpeed, transform.position.y);
        }*/
        // _fDistance = Mathf.PingPong(Time.time * _fSpeed, Vector2.Distance(start_point.position, end_point.position));

    }
}
