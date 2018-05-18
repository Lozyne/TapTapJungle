using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedColor : IColor {


    public void getColor(ObjectInGame pBody)
    {
        pBody.gsColor = 0;
        pBody.gameObject.GetComponent<Renderer>().material.color = Color.red;
        pBody.gsPoints = 10;
    }

}
