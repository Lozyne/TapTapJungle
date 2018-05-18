using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInGame : MonoBehaviour {

    private IColor _IColor;
    byte _Color;
    byte points;


    public byte gsColor
    {
        get
        {
            return this._Color;
        }
        set
        {
            this._Color = value;
        }
    }

    public IColor gsIColor
    {
        get
        {
            return this._IColor;
        }
        set
        {
            this._IColor = value;
        }
    }

    public byte gsPoints
    {
        get
        {
            return points;
        }
        set
        {
            this.points = value;
        }
    }
}
