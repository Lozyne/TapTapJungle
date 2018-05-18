using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBeatDetector : MonoBehaviour {

    public SimpleBeatDetection beatProcessor;

    private MeshRenderer myMeshRenderer;
    private Color beatedColor;
    public float smoothnessChange;
    int i = 0;
    void Start()
    {
        beatProcessor.OnBeat += OnBeat;
       // myMeshRenderer = GetComponent<MeshRenderer>();
        //beatedColor = Color.black;
    }

    void Update()
    {

       // beatedColor = Color.Lerp(beatedColor, Color.black, smoothnessChange * Time.deltaTime);

        //myMeshRenderer.material.color = beatedColor;
    }

    void OnBeat()
    {

        i++;
    }
}
