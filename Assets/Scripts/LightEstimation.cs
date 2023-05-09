using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LightEstimation : MonoBehaviour
{
    [Range(0f, 1f)]
    public float threshHold = 0.5f;

    public UnityEvent OnLightOn;
    public UnityEvent OnLightOff;

    bool lightOn;
    float lightValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("DebugText").GetComponent<TMP_Text>().text = Shader.GetGlobalFloat("_GlobalLightEstimation").ToString();
        lightValue = Shader.GetGlobalFloat("_GlobalLightEstimation");
        if(lightValue >= threshHold && !lightOn)
        {
            OnLightOn.Invoke();
            lightOn = true;
        }else if(lightValue < threshHold && lightOn)
        {
            OnLightOff.Invoke();
            lightOn= false;
        }


    }
    /*void OnValidate()
    {
        setGlobalLightEstimation(threshHold);
    }*/
    void setGlobalLightEstimation (float lightValue)
    {
        Shader.SetGlobalFloat("_GlobalLightEstimation", lightValue);
    }
}
