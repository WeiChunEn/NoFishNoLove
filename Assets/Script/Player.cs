using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Player : MonoBehaviour
{
    

   
    public enum AllPlayer
    {
        noPlayer,
        player1,
        player2

    }
    public AllPlayer _allPlayer = AllPlayer.noPlayer;
    
    private Rigidbody2D _rigi;
    private string _sPlayer = "";
    private string _sJump = "";

    public Player_Anime anime;
    

    public bool _bFacingRight = false;
    //public bool _bOnTheFood = false;
    /*[SerializeField]
    private bool _bCanJump = false;*/
    [SerializeField]
    private float _fJumpStart = 0.0f;
    [SerializeField]
    private float _fJumpTime = 5.0f;
    private float _fAxisX;
    /*[SerializeField]
    private bool _bJumping = false;*/
    [SerializeField]
    private float _fMoveforcex = 3.0f;
    [SerializeField]
    private float _fJumpforce = 6.0f;
    
    public Slider _gScore_Slider;
    [SerializeField]
    private float _fScoreControl;

    //angel add start
    PlayerData _data;
    //end

    void Awake()
    {
        //玩家設定
        switch (_allPlayer)
        {
            case AllPlayer.noPlayer:
                break;
            case AllPlayer.player1:
                _sPlayer = "Player1_Movement";
                _sJump = "Player1_Jump";
                _bFacingRight = true;
                break;
            case AllPlayer.player2:
                _sPlayer = "Player2_Movement";
                _sJump = "Player2_Jump";
                _bFacingRight = true;
                break;

        }
        




        _rigi = GetComponent<Rigidbody2D>();
        //angel
        _data = GetComponent<PlayerData>();//TODO:BUG
    }
    void FixedUpdate()
    {
        _fAxisX = Input.GetAxis(_sPlayer);
        if (_data.playerState != PlayerData.PlayerState.poison)
        {
            //移動
            if (_fAxisX != 0.0f)
            {
                
                Move(true);

            }
            else
            {
                Move(false);

            }
        }
        //跳躍
        /*if (Input.GetButtonDown(_sJump) && _fJumpStart > _fJumpTime)
        {
            _fJumpStart = 0.0f;*/
            //_bJumping = true;
           // Jump();
            
            /*if (_gUnderFoot != null && _bOnTheFood)
            {
                _gUnderFoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_fDownforce);
                switch (_gUnderFoot.tag)
                {
                    case "Hama":
                        //print(_gUnderFoot.GetComponent<Animator>());
                        _gUnderFoot.GetComponent<Animator>().SetBool("Open", true);
                        break;
                }
            }*/
       // }
       // _fJumpStart += Time.deltaTime;
        //if (!anime._bJumping && !anime._bMoving)
        //{
        //    anime._bIdling = true;
        //}


    }
    
    void Move(bool _bMoving)
    {
        if (_bMoving)
        {
            anime._bFishing = false;
            anime._bIdling = true;
            anime._bPosioning = false;
            //方向控制
            if (!_bFacingRight && _fAxisX > 0.0f)
            {
                gameObject.transform.Rotate(0, -180, 0);
                //print("right");
                _bFacingRight = true;
            }
            else if (_bFacingRight && _fAxisX < 0.0f)
            {
                gameObject.transform.Rotate(0, -180, 0);
                //print("left");
                _bFacingRight = false;
            }
            //移動
            _rigi.velocity = new Vector2(_fAxisX * _fMoveforcex, _rigi.velocity.y);
        }
        else
        {
            //if (_rigi.velocity.x != 0.0)
            _rigi.velocity = new Vector2(0.0f, _rigi.velocity.y);
        }
    }
    //跳躍
    void Jump()
    {

        _rigi.velocity = new Vector2(0, _fJumpforce);
       

    }
    
    void Start()
    {
        _fJumpStart = 5.0f;
        //angel add
       
    }

    // Update is called once per frame
    void Update()
    {
        //_fScoreControl = _gScore_Slider.value;
        

    }
    
}
