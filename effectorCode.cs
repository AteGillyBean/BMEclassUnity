using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectorCode : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public float sphereDistance;
    public Text distance;
    public Text redText;
    public float redCount;
    public float blueCount;
    public Text blueText;
    public float greenCount;
    public Text greenText;
    public float cyanCount;
    public float magCount;
    public float yellowCount;
    public Text cyanText;
    public Text magText;
    public Text yellowText;
    public float blackCount;
    public float whiteCount;
    public float greyCount;
    public Text blackText;
    public Text whiteText;
    public Text greyText;
    float[] rgbCounters=new float[3];
    public Color currentColor;
    public float currentHue;
    public float currentSat;
    public float currentVal;
    public Text colorText;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cube.transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            sphere = hit.transform.gameObject;
        }

        sphereDistance = sphere.transform.position.z + 10;
        distance.text = "Distance: " + sphereDistance.ToString();
        if(sphere.gameObject.name=="placeHolder")
        {
            distance.text = "Distance: --";
        }

        redCount = sphere.GetComponent<Renderer>().material.color.r;
        greenCount = sphere.GetComponent<Renderer>().material.color.g;
        blueCount = sphere.GetComponent<Renderer>().material.color.b;
        currentColor = sphere.GetComponent<Renderer>().material.color;
        rgbCounters[0] = redCount;
        rgbCounters[1] = greenCount;
        rgbCounters[2] = blueCount;
        blackCount = 1 - Mathf.Max(rgbCounters);
        Color.RGBToHSV(currentColor, out currentHue, out currentSat, out currentVal);
        currentHue *= 360;
        currentVal *= 100;
        currentSat *= 100;
        if (currentVal <= 8) //&& currentSat >= 30)
        {
            colorText.GetComponent<Text>().color = Color.black;
            colorText.text = "Black";
        }
        else
            if (currentSat <= 5 && currentVal >= 85)
        {
            colorText.GetComponent<Text>().color = Color.white;
            colorText.text = "White";
        }
        else
            if (currentSat <= 20 && currentVal >= 8 && currentVal <= 85)
        {
            colorText.GetComponent<Text>().color = Color.gray;
            colorText.text = "Grey";
        }
        else
        {
            if (currentHue >= 350 || currentHue <= 12)
            {
                colorText.GetComponent<Text>().color = Color.red;
                colorText.text = "Red";
            }
            if (currentHue >= 12 && currentHue <= 75)
            {
                colorText.GetComponent<Text>().color = Color.yellow;
                colorText.text = "Yellow";
            }
            if (currentHue >= 75 && currentHue <= 145)
            {
                colorText.GetComponent<Text>().color = Color.green;
                colorText.text = "Green";
            }
            if (currentHue >= 145 && currentHue <= 200)
            {
                colorText.GetComponent<Text>().color = Color.cyan;
                colorText.text = "Cyan";
            }
            if (currentHue >=200  && currentHue <= 270)
            {
                colorText.GetComponent<Text>().color = Color.blue;
                colorText.text = "Blue";
            }
            if (currentHue >= 270 && currentHue <= 350)
            {
                colorText.GetComponent<Text>().color = Color.magenta;
                colorText.text = "Magenta";
            }
        }

        if (changeColor.colorSelect == 3)
        {
            
            redText.text = "Red Count: " + (redCount*255f).ToString();
            
            greenText.text = "Green Count: " + (greenCount * 255f).ToString();
            
            blueText.text = "Blue Count: " + (blueCount * 255f).ToString();

            cyanText.text = "Cyan Count: --";
            magText.text = "Magenta Count: --";
            yellowText.text = "Yellow Count: --";
            blackText.text = "Black Count: --";
            whiteText.text = "White Count: --";
            greyText.text = "Grey Count: --";
        }
        
        if(changeColor.colorSelect==1)
        {
            if(sphere.GetComponent<Renderer>().material.color==Color.black)
            {
                cyanText.text = "Cyan Count: 0";
                magText.text = "Magenta Count: 0";
                yellowText.text = "Yellow Count: 0";
                redText.text = "Red Count: --";
                greenText.text = "Green Count: --";
                blueText.text = "Blue Count: --";
                blackText.text = "Black Count: --";
                whiteText.text = "White Count: --";
                greyText.text = "Grey Count: --";
            }
            else
            {
                cyanCount = (1 - redCount - blackCount) / (1 - blackCount);
                cyanText.text = "Cyan Count: " + (cyanCount * 255f).ToString();
                magCount = (1 - greenCount - blackCount) / (1 - blackCount);
                magText.text = "Magenta Count: " + (magCount * 255f).ToString();
                yellowCount = (1 - blueCount - blackCount) / (1 - blackCount);
                yellowText.text = "Yellow Count: " + (yellowCount * 255f).ToString();
                redText.text = "Red Count: --";
                greenText.text = "Green Count: --";
                blueText.text = "Blue Count: --";
                blackText.text = "Black Count: --";
                whiteText.text = "White Count: --";
                greyText.text = "Grey Count: --";
            }
        }
        
        if(changeColor.colorSelect==2)
        {
            
            blackText.text = "Black Count: " + (blackCount*255f).ToString();
            whiteCount = 1-blackCount;
            whiteText.text = "White Count: " + (whiteCount*255f).ToString();
            greyCount = (redCount/3+greenCount/3+blueCount/3)*255;
            greyText.text = "Grey Count: " + greyCount.ToString();
            redText.text = "Red Count: --";
            greenText.text = "Green Count: --";
            blueText.text = "Blue Count: --";
            cyanText.text = "Cyan Count: --";
            magText.text = "Magenta Count: --";
            yellowText.text = "Yellow Count: --";
        }
        sphere = GameObject.Find("placeHolder");
        
    }
}
