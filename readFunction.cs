using Palmmedia.ReportGenerator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class readFunction : MonoBehaviour
{
    private string[] seperatorContainer;
    private char[] seperator = {'X','Y','Z'};
    private string xString, yString, zString;
    private float xFloat, yFloat, zFloat;

    public string pathName2 = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\rotationCube.txt";

    // Start is called before the first frame update
    void Start()
    {
        readRotation();
    }

    // Update is called once per frame
    void Update()
    {
 
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
    }

    }
