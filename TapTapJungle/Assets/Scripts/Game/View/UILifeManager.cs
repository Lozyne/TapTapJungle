using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UILifeManager : MonoBehaviour {
    [SerializeField]
    private Image[] UIHearts;

    //public event EventH<UIEvents> Onlchange;
    public delegate void EventHandler();
    public event EventHandler  OnLifeChanged;

    public bool isHurting = false;

    private void Update()
    {
        if (isHurting)
        {
            OnLifeChanged();
            isHurting = false;
        }
            
    }

    public void LoseLife(int index)
    {
        UIHearts[index].gameObject.SetActive(false);
    }
}
