using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject _gGame;
    public GameObject _gStart;
    public Put_Fish _gPutFish;
    public GameObject  _gPlayer1, _gPlayer2;
    //public GameObject _gStartAnime;
    public GameObject _gStart_Title;
    public GameObject _gStart_Background;
    public GameObject _gStart_Stuff;
    public GameObject _gStart_Game;
    public GameObject _gStart_Help;
    public GameObject _gStart_CloBtn;


    public GameObject _gStuff_Stuff;

    public GameObject _gHelp_Help;

    public GameObject _gGame_UI;

    public GameObject _gEndPlayer1Win;
    public GameObject _gEndPlayer2Win;

     public GameObject _gEnd_Start;
    public GameObject _gEnd_Game;
    //public GameObject _gEnd_Background;
    public GameObject _gEnd_Btn;
    public Camera _gCamera;
    public AudioClip _audioMenu;
    public AudioClip _audioGame;
    public AudioClip _audioPlayer1Win;
    public AudioClip _audioPlayer2Win;

    public enum AllMenu
    {
        Menu,
        Help,
        Staff,
        Game,
        End
    }
    public AllMenu nowMenu = AllMenu.Menu;

    public bool _bPlayer1Win = false;
    public bool _bPlayer2Win = false;
    bool _bEnd = false;

    public bool _bGoNewGame = false;
    public float _fGoNewGameing = 0.0f;
    public float _fGoNewGameTime = 6.0f;
    void Start ()
    {
        _gCamera.GetComponent<AudioSource>().clip = _audioMenu;
        _gCamera.GetComponent<AudioSource>().Play();
    }
	
	
	void Update ()
    {
        if(_gPlayer1.GetComponent<PlayerData>().score >= 100)
        {
            _bPlayer1Win = true;
            nowMenu = AllMenu.End;
        }
        else if(_gPlayer2.GetComponent<PlayerData>().score >= 100)
        {
            _bPlayer2Win = true;
            nowMenu = AllMenu.End;
        }
        
        switch (nowMenu)
        {
            case AllMenu.Game:
                //Game();
                break;
            case AllMenu.End:
                if (!_bEnd)
                {
                    End();
                }
                break;
        }
        if (_bGoNewGame)
        {
            GoNewGame();
        }
    }
    void Game()
    {
        if ( !_bPlayer1Win && !_bPlayer2Win)
        {
            
            //_gPutFish.FishUpdate();
        }
        else
        {
            nowMenu = AllMenu.End;
        }
    }
    bool GoNewGame()
    {
        bool _bGoNewGameing = false;
        if (_fGoNewGameing <= _fGoNewGameTime)
        {
            _bGoNewGameing = true;
            _fGoNewGameing += Time.deltaTime;
        }
        //時間到
        else
        {
            _fGoNewGameing = 0.0f;
            _bGoNewGame = false;
            _bGoNewGameing = false;
            Application.LoadLevel(Application.loadedLevel);
            //SceneManager.LoadScene("Temp");
        }
        return _bGoNewGameing;
    }
    void End()
    {
        //print("end");
        if (_bPlayer1Win)
        {
            _gGame.SetActive(false);
            _gCamera.GetComponent<AudioSource>().clip = _audioPlayer1Win;
            _gCamera.GetComponent<AudioSource>().Play();
            _gEndPlayer1Win.SetActive(true);
            _gEndPlayer2Win.SetActive(false);
            _gEnd_Start.SetActive(false);
            _gEnd_Game.SetActive(false);
            //_gEnd_Background.SetActive(false);
           // _gEnd_Btn.SetActive(true);
            //print("Player1Win");
        }
        else if (_bPlayer2Win)
        {
            _gGame.SetActive(false);
            _gCamera.GetComponent<AudioSource>().clip = _audioPlayer2Win;
            _gCamera.GetComponent<AudioSource>().Play();
            
            _gEndPlayer1Win.SetActive(false);
            _gEndPlayer2Win.SetActive(true);
            _gEnd_Start.SetActive(false);
            _gEnd_Game.SetActive(false);
            //_gEnd_Background.SetActive(false);
            //_gEnd_Btn.SetActive(true);
            //print("Player2Win");
        }
        
        _bEnd = true;
        _bGoNewGame = true;
    }
    /*public void StartAnime()
    {
        _gStartAnime.S
    }*/
    public void StartMenuBtn()
    {
        nowMenu = AllMenu.Menu;
        _gStart_Stuff.SetActive(true);
        _gStart_Game.SetActive(true);
        _gStart_Help.SetActive(true);
        //_gStart_CloStuff.SetActive(false);
        _gStuff_Stuff.SetActive(false);
        _gHelp_Help.SetActive(false);
        _gGame.SetActive(false);
        
        //print("GoToStartMenu");
    }
    public void HelpBtn()
    {
        nowMenu = AllMenu.Help;
        _gStart_Background.SetActive(false);
        _gStart_Title.SetActive(false);
        _gStart_Stuff.SetActive(false);
        _gStart_Game.SetActive(false);
        _gStuff_Stuff.SetActive(false);
        _gStart_CloBtn.SetActive(true);
        _gStart_Help.SetActive(false);
        _gHelp_Help.SetActive(true);
        _gGame.SetActive(false);
        //print("GoToHelp");
    }
    public void StuffBtn()
    {
        nowMenu = AllMenu.Staff;
        _gStart_Background.SetActive(false);
        _gStart_CloBtn.SetActive(true);
        _gStart_Title.SetActive(false);
        _gStart_Stuff.SetActive(false);
        _gStart_Game.SetActive(false);
        _gStart_Help.SetActive(false);
        _gStuff_Stuff.SetActive(true);
        _gHelp_Help.SetActive(false);
        _gGame.SetActive(false);
        //print("GoToStuff");
    }
    public void GameBtn()
    {
        nowMenu = AllMenu.Game;
        _gStart.SetActive(false);
        //_gStart_Title.SetActive(false);
        //_gStart_Stuff.SetActive(false);
        //_gStart_Game.SetActive(false);
        //_gStart_Help.SetActive(false);
        //_gStuff_Stuff.SetActive(false);
        //_gHelp_Help.SetActive(false);
        _gGame.SetActive(true);
        //_gGame_UI.SetActive(true);
        _gCamera.GetComponent<AudioSource>().clip = _audioGame;
        _gCamera.GetComponent<AudioSource>().Play();


        _gCamera.GetComponent<AudioSource>().clip = _audioGame;
        _gCamera.GetComponent<AudioSource>().Play();
        //print("GoToGame");
    }
    public void CloseBtn()
    {
        nowMenu = AllMenu.Menu;
        _gStart_Background.SetActive(true);
        _gStart_CloBtn.SetActive(false);
        _gStart_Title.SetActive(true);
        _gStart_Stuff.SetActive(true);
        _gStart_Game.SetActive(true);
        _gStart_Help.SetActive(true);
        _gStuff_Stuff.SetActive(false);
        _gHelp_Help.SetActive(false);
        _gGame.SetActive(false);
    }
    public void PlayerWin(Player.AllPlayer _whichPlayer)
    {
        nowMenu = AllMenu.End;
        switch (_whichPlayer)
        {
            case Player.AllPlayer.noPlayer:
                break;
            case Player.AllPlayer.player1:
                _bPlayer1Win = true;
                break;
            case Player.AllPlayer.player2:
                _bPlayer2Win = true;
                break;
        }
    }
    public void RestartBtn()
    {
       
        _gEndPlayer1Win.SetActive(false);
        _gEndPlayer2Win.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }
}
