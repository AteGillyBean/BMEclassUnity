using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class dataCollection : MonoBehaviour
{
    public GameObject dataObject; //object of interest/reference (data points: force, poosition, rotation, etc.)
    public bool writeStatus = false;
    public string pathName = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\dataToolbox.txt";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (writeStatus == true)
        {
            writeData();
        }
    }

    void writeData()
    {
        using(StreamWriter file = new StreamWriter(pathName, true))
        {
            string output = string.Format("PositionX, {0}", dataObject.transform.position.x);
            file.WriteLine(output); 
        }
    }
        void clearData()
    {
        using (StreamWriter file = new StreamWriter(pathName, false))
        {
            file.WriteLine();
        }
    }

    private void OnGUI()
    {
        //pathName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pathName);
        if (GUI.Button(new Rect(200, Screen.height - 40, 80, 30), "Write"))
        {
            writeStatus = true;
            Debug.Log("Write");
        }

        if (GUI.Button(new Rect(300, Screen.height - 40, 80, 30), "Stop"))
        {
            writeStatus = false;
            Debug.Log("Stop");
        }

        if (GUI.Button(new Rect(400, Screen.height - 40, 80, 30), "Clear"))
        {
            clearData();
            Debug.Log("Clear");
        }
    }

    }
