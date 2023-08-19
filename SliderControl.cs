using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Using UI Element of Sliders

public class SliderControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RBC_Cannister, Virus_Cannister; // Define Cannisters to translate
    public Slider RBC_Slider, Virus_Slider; // Define Sliders
    private float RBC_Val, Virus_Val; // Define current Slider value
    void Start()
    {
        // Use Inspector to set up Sliders and GameObjects
        // Script is attached to RBC slider only, since it references the other via Inspector
    }

    // Update is called once per frame
    void Update()
    {

        // RBC Slider
        Slider RBCSlider = RBC_Slider.GetComponent<Slider>();
        RBC_Val = RBCSlider.value;
        RBC_Cannister.transform.position = new Vector3(-6,RBC_Val,0);
        // Virus Slider
        Slider VirusSlider = Virus_Slider.GetComponent<Slider>();
        Virus_Val = VirusSlider.value;
        Virus_Cannister.transform.position = new Vector3(-6, -Virus_Val, 0);

    }
}
