using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager {
    public static DataManager _DataManager;
    private byte _Score;
    private List<byte> _BodiesListNumbers;
    private byte _BodiesNumber;
    private const byte _ComboPoints = 100;

   
    // Use this for initialization
    public DataManager()
    {
        _DataManager = this;
        _Score = 0;
        _BodiesListNumbers = new List<byte>();
        _BodiesNumber = 0;
        _BodiesListNumbers.Add(0);
        _BodiesListNumbers.Add(0);
        _BodiesListNumbers.Add(0);

    }

    //SCORE
    public byte gsScore
    {
        get
        {
            return this._Score;
        }
        set
        {
            this._Score += value;
        }
    }
    
    //Number of bodies for each colors
    public List<byte> gsBodiesListNumber
    {
        get
        {
            return this._BodiesListNumbers;
        }
        set
        {
            this._BodiesListNumbers = value;
        }
    }

    public void addBodiesNumberValue(byte index)
    {
        _BodiesListNumbers[index]++;
        _BodiesNumber++;
    }

    public void removeBodiesNumberValue(byte index)
    {
        _BodiesListNumbers[index]--;
    }

    public byte gsComboConstPoints
    {
        get
        {
            return _ComboPoints;
        }
    }

    public byte gsBodiesNumber
    {
        get
        {
            return _BodiesNumber;
        }
    } 

   

}
