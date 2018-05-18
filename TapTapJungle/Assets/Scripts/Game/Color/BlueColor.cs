using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueColor : IColor
{
    public void getColor(ObjectInGame pBody)
    {
        pBody.gsColor = 1;
        pBody.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        pBody.gsPoints = 10;
    }

}
