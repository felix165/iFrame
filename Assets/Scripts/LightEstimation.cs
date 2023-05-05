using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEstimation : MonoBehaviour
{
    [Range(0f, 1f)]
    public float value = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setGlobalLightEstimation(frame.LightEstimate.PixelIntensity);
    }
    void OnValidate()
    {
        setGlobalLightEstimation(value);
    }
    void setGlobalLightEstimation (float lightValue)
    {
        Shader.SetGlobalFloat("_GlobalLightEstimation", lightValue);
    }
}
