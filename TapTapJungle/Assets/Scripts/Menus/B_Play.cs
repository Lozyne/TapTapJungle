using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Play : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void B_PlayGame()
    {
        UIManager.UI_Manager.gsUIMenu.SetActive(false);
        UIManager.UI_Manager.launchTimer();
        //Manager_Game.gameManager.gsIngame = true;

    }
}
