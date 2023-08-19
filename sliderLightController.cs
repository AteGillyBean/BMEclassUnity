using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderLightController : MonoBehaviour
{
    public Light sliderLight;
    public Slider intensitySlider;
    public float intensityValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        intensityValue = intensitySlider.value;
        sliderLight.intensity = intensitySlider.value;
        //Debug.Log(intensityValue);
    }
}
