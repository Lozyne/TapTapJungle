using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add 2 balls to the last ball to delete it 3 last balls (2 times)
/// </summary>
public class YellowColor : IColor {

    public void getColor(ObjectInGame pBox)
    {
        pBox.gsColor = 3;
        pBox.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        pBox.gsPoints = 0;
    }
}
