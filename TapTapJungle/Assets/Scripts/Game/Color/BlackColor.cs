using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eat one heart
/// </summary>
public class BlackColor : IColor {

    public void getColor(ObjectInGame pBox)
    {
        pBox.gsColor = 4;
        pBox.gameObject.GetComponent<Renderer>().material.color = Color.black;
        pBox.gsPoints = 30;
    }

}
