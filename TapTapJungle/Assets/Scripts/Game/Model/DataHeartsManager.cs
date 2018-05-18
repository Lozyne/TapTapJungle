using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataHeartsManager {
    public static DataHeartsManager _DataHeartsManager;
    byte nbrLife = 3;
    public delegate void EventHandler();
    public event EventHandler OnDataChanged;

    public DataHeartsManager()
    {
        _DataHeartsManager = this;
    }

    public byte gsLife
    {
        get
        {
            return nbrLife;
        }

        set
        {
            nbrLife = value;
            OnDataChanged();
        }
    }
}
