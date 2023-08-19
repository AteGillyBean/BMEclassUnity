using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightController : MonoBehaviour
{
    public GameObject lamp;
    public Light operatingRoomLight;
    public float defaultIntensity = 10;
    public Button lightSwitch;

    //to change your values/factors

    // Start is called before the first frame update
    void Start()
    {
        lamp = GameObject.FindGameObjectWithTag("lamp");
        //operatingRoomLight = GameObject.FindGameObjectWithTag("pointLight"); wrong to label with
        operatingRoomLight = lamp.GetComponentInChildren<Light>(); 
        operatingRoomLight.intensity = defaultIntensity;
        lightSwitch.onClick.AddListener(lightsOut); // referenced in a void called lightsout below
        //
    }

    // Update is called once per frame
    void Update()

        // myLight.intensity = mySlider.value;
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            defaultIntensity--;
            operatingRoomLight.intensity = defaultIntensity;
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            defaultIntensity++;
            operatingRoomLight.intensity = defaultIntensity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            operatingRoomLight.color = Random.ColorHSV();
        }
    }

    void lightsOut()
    {
        // mySlider.value = 0;
        operatingRoomLight.intensity = 0;
    }
}
