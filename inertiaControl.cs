using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class inertiaControl : MonoBehaviour
{


public SerialPort serial = new SerialPort("\\\\.\\COM15", 115200);
private string eulerString;
private string[] eulerParse;
private char[] seperator = { 'Y', 'Z' };
private string eulerStringX, eulerStringY, eulerStringZ;
public float eulerFloatX, eulerFloatY, eulerFloatZ;
private float startX, startY, startZ;
private float driftCorrectionX, initialY, initialZ;


// Use this for initialization
void Start()
{

    serial.Open();
    Debug.Log("Arm Tracking Active: ");

    startX = transform.position.x;
    startY = transform.position.y;
    startZ = transform.position.z;


}

// Update is called once per frame
void Update()
{

    eulerString = serial.ReadLine();


    eulerParse = eulerString.Split(seperator);

    eulerStringX = eulerParse[0];
    eulerStringY = eulerParse[1];
    eulerStringZ = eulerParse[2];



    float.TryParse(eulerStringX, out eulerFloatX);
    float.TryParse(eulerStringY, out eulerFloatY);
    float.TryParse(eulerStringZ, out eulerFloatZ);


    driftCorrectionX = 60f;
    initialY = 0.94f;
    initialZ = 9.19f;
    


        //transform.position=new Vector3 ((eulerFloatX * Time.deltaTime)+startX,(eulerFloatZ*Time.deltaTime)+ startY,(eulerFloatY*Time.deltaTime)+startZ);
        // transform.position = new Vector3(.1f * (eulerFloatX - initialX), -0.1f * (eulerFloatZ - initialZ), 0.1f * (eulerFloatY - initialY));
        transform.localEulerAngles=new Vector3(eulerFloatY, eulerFloatX-driftCorrectionX, -eulerFloatZ );


}


}
