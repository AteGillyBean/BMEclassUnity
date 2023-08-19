using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{
    public GameObject sphere;
    public Slider colorChoice;
    public static float colorSelect;
    public int zPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colorSelect = colorChoice.value;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            sphere.GetComponent<Renderer>().material.color = newColor;
        }
        if(Input.GetKey(KeyCode.Keypad1))
        {
            Color redColor = new Color(1f, 0f, 0f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = redColor;
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            Color greenColor = new Color(0f, 1f, 0f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = greenColor;
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            Color blueColor = new Color(0f, 0f, 1f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = blueColor;
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            Color cyanColor = new Color(0f, 1f, 1f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = cyanColor;
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            Color magentaColor = new Color(1f, 0f, 1f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = magentaColor;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            Color yellowColor = new Color(1f, 1f, 0f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = yellowColor;
        }
        if (Input.GetKey(KeyCode.Keypad7))
        {
            Color blackColor = new Color(0f, 0f, 0f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = blackColor;
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            Color whiteColor = new Color(1f, 1f, 1f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = whiteColor;
        }
        if (Input.GetKey(KeyCode.Keypad9))
        {
            Color greyColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            sphere.GetComponent<Renderer>().material.color = greyColor;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            zPos = Random.Range(-5, 6);
            sphere.transform.position = new Vector3(12, 1, zPos);
        }
        if(sphere.transform.position.x>0)
        {
            sphere.transform.Translate(-6* Time.deltaTime, 0, 0);
        }
        
    }
}
