using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Game : MonoBehaviour {
    public static Manager_Game gameManager;
    
    private UIManager S_UIManager;
    private const int _maxBall = 20;
    private bool _InGame;

    private byte initValueBodies;
    AudioListener _audio;
    [SerializeField]
    AudioSource _Sound;

    [SerializeField]
    private Snake _Snake;

    [SerializeField]
    private Camera _Camera;

    private BodyManager _BodyManager;
    // Use this for initialization

    private void Start()
    {
           
         gameManager = this;
        initValueBodies = 5;
        _BodyManager = BodyManager._BodyManager;
        S_UIManager = UIManager.UI_Manager;
        initGame();
       _InGame = false;
      
    }

    private void FixedUpdate()
    {
        if (gsIngame == true && !_Sound.GetComponent<AudioSource>().isPlaying)
            stopGame();
    }

    protected void initSnake()
    {
        GameObject head = Instantiate(_BodyManager.gsPrefabHead);//, _Snake.gsBodiesObjects.transform);
        head.name = "head";
        head.tag = "head";
       
        _Snake.addBody(head.GetComponent<Body>());
        head.transform.localPosition = new Vector3(0, 0.52f, 0);//20.04f
        head.GetComponent<Body>().gsIsHead=true;
        _BodyManager.initPositionBodies(1);

        _Camera.transform.parent = head.transform;
       _Camera.transform.position = new Vector3(head.transform.position.x, head.transform.position.y+4, head.transform.position.z-10.0f);

        
    }
    
    public Snake getSnake()
    {
        return _Snake;
    }

    public void initGame()
    {
        initSnake();
        _BodyManager.initListObjectsInGame();
        _BodyManager.initPositionBodies(initValueBodies);
    }

    public void stopGame()
    {
        _Snake.GetComponent<Snake>().enabled = false;
        S_UIManager.gsMenu_EndGame.SetActive(true);
        S_UIManager.gsButton_Pause.SetActive(false); 
    }

    public void pauseGame()
    {
        _Sound.GetComponent<AudioSource>().Pause();
        _Snake.GetComponent<Snake>().enabled = false;
        S_UIManager.gsMenu_UIPause.SetActive(true);
        S_UIManager.gsButton_Pause.SetActive(false);
        S_UIManager.gsButton_Play.SetActive(true);
    }

    public void playGame()
    {
        _Sound.GetComponent<AudioSource>().Play();
        _Snake.GetComponent<Snake>().enabled = true;
        S_UIManager.gsMenu_UIPause.SetActive(false);
        S_UIManager.gsButton_Pause.SetActive(true);
        S_UIManager.gsButton_Play.SetActive(false);
    }

    public bool gsIngame
    {
        get
        {
            return this._InGame;
        }
        set
        {
            this._InGame = value;
        }
    }

    public BodyManager gsBodyManager
    {
        get
        {
            return this._BodyManager;
        }

    }

    public void launchSpeedSnake()
    {
        StartCoroutine("launchSpeedValue");
    }
     
    IEnumerator launchSpeedValue()
    {
        yield return new WaitForSeconds(5.0f);
        while (_InGame==true && !_Snake.gsMoving)
        {
            float oldSpeed = _Snake.gsSpeed;
            _Snake.gsSpeed = _Snake.gsSpeed + 2.0f;
            if(_Snake.gsSpeed>3.0f)
                _Snake.gsCoef_Dist = (_Snake.gsCoef_Dist * _Snake.gsSpeed)/ oldSpeed;
            yield return new WaitForSeconds(20.0f);
        }
        
    }

    public void launchMusic()
    {
        _Sound.GetComponent<AudioSource>().Play();
      
    }


}
