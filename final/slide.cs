using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slide : MonoBehaviour
{

    public GameObject RCan, GCan; //moving cans
    public Slider RSlider, GSlider; 
    private float RVal, GVal; 

    void Update()
    {

        //Red
        Slider RSlide = RSlider.GetComponent<Slider>();
        RVal = RSlider.value;
        RCan.transform.position = new Vector3(-7, RVal, 0); //(position of can, move up, no move)
        
        //Green
        Slider GSlide = GSlider.GetComponent<Slider>();
        GVal = GSlide.value;
        GCan.transform.position = new Vector3(-7, -GVal, 0); //(position of can, move up, no move)
    }
}
