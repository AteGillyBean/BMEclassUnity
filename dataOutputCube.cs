using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using UnityEngine.UI;
using Palmmedia.ReportGenerator.Core;

public class dataOutputCube : MonoBehaviour
{
    public float hSpeed = 0.5f;
    public float vSpeed = 0.5f;

    public float xPos, yPos, zPos, xRot, yRot, zRot;
    public string pathName = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\translateCube.txt"; //change file name for each play run
    public string pathName2 = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\rotationCube.txt";

    public GameObject translateCube;
    public Slider translationCube;
    private float translationValue;

    private string[] seperatorContainer;
    private char[] seperator = {'X','Y','Z'};
    private string xString, yString, zString;
    private float xFloat, yFloat, zFloat;

    // Start is called before the first frame update
    void Start()
    {
        //clearPosition(); // clear data before each play run is activated
        //clearRotation();

        translateCube = GameObject.FindGameObjectWithTag("translate");
        translationCube = translateCube.GetComponent<Slider>();
        // collect rotation and traslation data with gui implementation

        readRotation();
    }

    // Update is called once per frame
    void Update()
    {
        float h = hSpeed * Input.GetAxis("Mouse X");
        float v = vSpeed * Input.GetAxis("Mouse Y");
        translationValue = translationCube.value;

        transform.Rotate(v, h, 0);
        transform.Translate(translationValue, 0, 0);
        //transform.Translate(h, v, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        xPos = transform.position.x;
        yPos = transform.position.y;
        xRot = transform.localEulerAngles.x;
        yRot = transform.localEulerAngles.y;
        zRot = transform.localEulerAngles.z;

        //Debug.Log("Horizontal: " + h); values of h
        //Debug.Log("Vertical: " + v); values of v

        writeTransformPosition(); //comment out to clear file
        writeTransformRotation();

    }

    private void writeTransformPosition()
    {
        using (System.IO.StreamWriter file = new StreamWriter(pathName, true))
        {
            string output = string.Format("{0}, X, {1}, Y, {2}, Z", xPos, yPos, zPos); 

            file.WriteLine(output); 
        }
    }

    private void writeTransformRotation()
    {
        using (System.IO.StreamWriter file = new StreamWriter(pathName2, true))
        {
            string output = string.Format("X{0}Y{1}Z{2}", xRot, yRot, zRot);

            file.WriteLine(output);
        }
    }

    private void clearPosition()
    {
        using (System.IO.StreamWriter file2 = new StreamWriter(pathName, false))
        {
            
        }
    }

    private void clearRotation()
    {
        using (System.IO.StreamWriter file2 = new StreamWriter(pathName2, false))
        {

        }
    }

    private void readRotation()
    {
        var rotationStorage = File.ReadAllText(pathName2);
        var dataLength = rotationStorage.Length;
        
        StreamReader readRoation = new StreamReader(pathName2);
        
         string rotationData = "";

        var i = 0;

        while (i < dataLength)
        {
            rotationData = readRoation.ReadLine();
            Debug.Log(rotationData);
            i++; // reads the length of file and each line coming in
            //Debug.Log("Index Val: " + i);

            seperatorContainer = rotationData.Split(seperator); // read individual values and split data packet

            xString = seperatorContainer[0];
            yString = seperatorContainer[1];
            zString = seperatorContainer[2];

            float.TryParse(xString, out xFloat); // conversion from string to float
            float.TryParse(yString, out yFloat);
            float.TryParse(zString, out zFloat);
            Debug.Log("X Rot: " + xFloat);
            Debug.Log("Y Rot: " + yFloat);
            Debug.Log("Z Rot: " + zFloat);
        }
        
        //foreach (char s in rotationData)
        //{
        //    Debug.Log(s);   
        //}
    }
}
