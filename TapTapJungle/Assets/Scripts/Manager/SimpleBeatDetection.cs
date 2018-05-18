using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBeatDetection : MonoBehaviour {

    public AudioListener audioSource;

    public delegate void OnBeatHandler();
    public event OnBeatHandler OnBeat;


    private float[] samples0Channel;
    private float[] samples1Channel;

    private float[] historyBuffer;

    public int bufferSize =1024;

    public FFTWindow FFTWindow;

    public bool isWaiting;

    // Use this for initialization
    void Start() {
        samples0Channel = new float[bufferSize];
        samples1Channel = new float[bufferSize];
        historyBuffer = new float[43];
        isWaiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        float instantEnergy = GetInstantEnergy();

        float localAverageEnergy = GetLocalAverageEnergy();

        float varianceEnergies = ComputeVariance(localAverageEnergy);

        double constantC = (-0.0025714 * varianceEnergies) + 1.5142857;

        float[] shiftedHistoryBuffer = ShiftArray(historyBuffer, 1);

        shiftedHistoryBuffer[0] = instantEnergy;
        //Debug.Log(constantC * localAverageEnergy);
        OverrideElementsToAnotherArray(shiftedHistoryBuffer, historyBuffer);

        if (instantEnergy > constantC * localAverageEnergy)
        {
            
            // Beat!
            if (OnBeat != null && !isWaiting)
            {
                Debug.Log(instantEnergy);
                isWaiting = true;
                StartCoroutine("WaitCoroutine");
                OnBeat();
                
            }
               
        }

    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        isWaiting = false;
    }

    #region FOR_SIMPLE_ALGORITHM_USE
    public float GetInstantEnergy()
    {

        float result = 0;

        // Fill the samples arrays
        // Each value of these arrays are floats between 0 and 1
        // and are the frequency percentage of use
        AudioListener.GetSpectrumData(samples0Channel, 0, FFTWindow);
        AudioListener.GetSpectrumData(samples1Channel, 1, FFTWindow);
       
        // Refer to reference: e = sum(a[i]^2 + b[i]^2)
        for (int i = 0; i < bufferSize; i++)
        {
            result += (float)System.Math.Pow(samples0Channel[i], 2) + (float)System.Math.Pow(samples1Channel[i], 2);
        }

        return result;
    }

    private float GetLocalAverageEnergy()
    {
        float result = 0;

        // Refer to reference: <E> = sum(E[i]^2) / 43

        for (int i = 0; i < historyBuffer.Length; i++)
        {
            // TODO See if getting out the square of this element works better
            result += historyBuffer[i];
        }

        return result / historyBuffer.Length;
    }

    private float ComputeVariance(float _averageEnery)
    {
        float result = 0;

        // Refer to reference: V = sum( (E[i] - <E>)^2 ) / 43

        for (int i = 0; i < historyBuffer.Length; i++)
        {
            result += (float)System.Math.Pow(historyBuffer[i] - _averageEnery, 2);
        }

        return result / historyBuffer.Length;
    }
    #endregion

    #region UTILITY_USE
    private void OverrideElementsToAnotherArray(float[] _from, float[] _to)
    {
        for (int i = 0; i < _from.Length; i++)
        {
            _to[i] = _from[i];
        }
    }

    private float[] ShiftArray(float[] _array, int amount)
    {

        float[] result = new float[_array.Length];

        for (int i = 0; i < _array.Length - amount; i++)
        {
            result[i + amount] = _array[i];
        }

        return result;

    }

    private string historybuffer()
    {
        string s = "";
        for (int i = 0; i < historyBuffer.Length; i++)
        {
            s += (historyBuffer[i] + ",");
        }
        return s;
    }
    #endregion
}


