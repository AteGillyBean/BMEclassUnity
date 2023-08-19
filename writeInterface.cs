using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class writeInterface : MonoBehaviour
{
    public float hSpeed = 0.5f;
    public float vSpeed = 0.5f;
    public float hMouseSpeed = 0.5f;
    public float vMouseSpeed = 0.5f;
    public float xPos, yPos, zPos, xRot, yRot, zRot;
    
    private bool writeCondition = false;
    public string pName = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\writeInterface.txt";
    public string patName = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\writeInterface.txt";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = hSpeed * Input.GetAxis("Horizontal");
        float v = vSpeed * Input.GetAxis("Vertical");
        float hMouse = hMouseSpeed * Input.GetAxis("Mouse X");
        float vMouse = vMouseSpeed * Input.GetAxis("Mouse Y");

        transform.Translate(h, v, 0);
        transform.Rotate(vMouse, hMouse, 0);

        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        xRot = transform.localEulerAngles.x;
        yRot = transform.localEulerAngles.y;
        zRot = transform.localEulerAngles.z;

        if (writeCondition == true)
        {
            writeData();
        }
    }

    private void writeData()
    {
        using (StreamWriter file = new StreamWriter(pName, true))
        {
            string output = string.Format("X{0} Y{1} Z{2} x{3} y{4} z{5}", xPos, yPos, zPos, xRot, yRot, zRot);
            file.WriteLine(output);
        }
    }

    public void ChangeName(string newName)
    {
        pName = newName;
    }

    public void clearData()
    {
        StreamWriter file = new StreamWriter(pName, false);
    }

    public void readData()
    {
        using (StreamReader file = new StreamReader(patName, true))
        {
            Debug.Log(file.ReadToEnd());
            file.Close();
        }
    }

    private void OnGUI()
    {
        pName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pName); 
        if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Path"))
        {
            ChangeName(pName);
        }

        if (GUI.Button(new Rect(220, Screen.height - 40, 80, 30), "Write"))
        {
            writeCondition = true;
        }

        if (GUI.Button(new Rect(310, Screen.height - 40, 80, 30), "Stop"))
        {
            writeCondition = false;
        }

        if (GUI.Button(new Rect(400, Screen.height - 40, 80, 30), "Clear"))
        {
            clearData();
        }

        if (GUI.Button(new Rect(490, Screen.height - 40, 80, 30), "Read"))
        {
            readData();
        }
    }
}
