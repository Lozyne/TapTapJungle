using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public static UIManager UI_Manager;

    Manager_Game _GameManager;
    
    [SerializeField]
    GameObject UI_Menu, Menu_Pause, Menu_EndGame;

    [SerializeField]
    GameObject Button_Play, Button_Credit, Button_Parameter, Button_Pause, Button_Replay, Button_Quit;

    [SerializeField]
    GameObject[] _Timer;
    

    [SerializeField]
    private Text _TxtScore;

    [SerializeField]
    private Image[] _UIColors;

    [SerializeField]
    private GameObject[] lstDelimitation;

    private void Awake()
    {   
        UI_Manager = this;
       
        _GameManager = Manager_Game.gameManager;
    }

    public string _UIScore
    {
        get
        {
            return _TxtScore.ToString();
        }
        set
        {
            _TxtScore.text = value;
        }
    }

    /// <summary>
    /// setting colors for the balls UI
    /// </summary>
    /// <param name="color"></param>
    public void setUIColors(Color color)
    {
        if (color!= Color.magenta)//add color
        {
            _UIColors[2].color = _UIColors[1].color;
            _UIColors[1].color = _UIColors[0].color;
            _UIColors[0].color = color;
        }
        else//remove
        {
            List<Body> lstBodies = _GameManager.getSnake().getLstBody();
            _UIColors[2].color = lstBodies[lstBodies.Count - 3].GetComponent<Renderer>().material.color;
            _UIColors[1].color = lstBodies[lstBodies.Count - 2].GetComponent<Renderer>().material.color;
            _UIColors[0].color = lstBodies[lstBodies.Count - 1].GetComponent<Renderer>().material.color;
        }
    }

    public GameObject gsUIMenu
    {
        get
        {
            return UI_Menu;
        }
    }

    public GameObject gsMenu_UIPause
    {
        get
        {
            return Menu_Pause;
        }
    }

    public GameObject gsMenu_EndGame
    {
        get
        {
            return Menu_EndGame;
        }
    }

    public GameObject gsButton_Play
    {
        get
        {
            return Button_Play;
        }
    }

    public GameObject gsButton_Pause
    {
        get
        {
            return Button_Pause;
        }
    }

    public void launchTimer()
    {
        StartCoroutine("startTimer");
    }

    IEnumerator startTimer()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i<3;i++)
        {

            yield return new WaitForSeconds(1.0f);
            _Timer[i].SetActive(false);
            
        }
        Manager_Game.gameManager.gsIngame = true;
        Manager_Game.gameManager.launchMusic();
        Manager_Game.gameManager.launchSpeedSnake();
    }


    public GameObject[] gsListDelimitation
    {
        get
        {
            return lstDelimitation;
        }
    }
}
