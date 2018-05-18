using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenColor : IColor
{
    public void getColor(ObjectInGame pBody)
    {
        pBody.gsColor = 2;
        pBody.gameObject.GetComponent<Renderer>().material.color = Color.green;
        pBody.gsPoints = 10;
    }


}
