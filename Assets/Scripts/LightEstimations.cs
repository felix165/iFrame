using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LightEstimations : MonoBehaviour
{
    public ARCameraManager arcamman;
    //public TMP_Text brightness;
    Light our_light;
    [HideInInspector]
    public static float brightness;
    
    // Start is called before the first frame update
    void Start()
    {
        our_light = GetComponent<Light>();

    }

    void OnEnable()
    {
        arcamman.frameReceived += getlight;
    }

    void OnDisable()
    {
        arcamman.frameReceived -= getlight;
    }

    
    void getlight(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.mainLightColor.HasValue)
        {
            //brightness.text=$"Color_value:{args.lightEstimation.mainLightColor.Value}";
            our_light.color = args.lightEstimation.mainLightColor.Value;
            brightness = 0.2126f * our_light.color.r + 0.7152f * our_light.color.g + 0.0722f * our_light.color.b;
            //brightness /= 255f;
            GameObject.Find("DebugText").GetComponent<TMP_Text>().text = brightness.ToString();
        }
    }


}
