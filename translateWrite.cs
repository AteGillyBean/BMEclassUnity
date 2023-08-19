using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class translateWrite : MonoBehaviour
{

    public float xPos, yPos, zPos, xRot, yRot, zRot;
    public float hSpeed = 0.5f;
    public float vSpeed = 0.5f;

    public GameObject translateCube;
    public Slider translationCube;
    private float translationValue;

    public string pathName = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\translateCube.txt";
    public string pathName2 = @"C:\Users\Owner\Desktop\njit\bme 673 - biorobotics\UnityData\rotationCube.txt";

    // Start is called before the first frame update
    void Start()
    {
        translateCube = GameObject.FindGameObjectWithTag("translate");
        translationCube = translateCube.GetComponent<Slider>();
        //clearPosition();
        //clearRotation();
    }

    // Update is called once per frame
    void Update()
    {
        float h = hSpeed * Input.GetAxis("Mouse X");
        float v = vSpeed * Input.GetAxis("Mouse Y");
        translationValue = translationCube.value;

        transform.Rotate(v, h, 0);
        transform.Translate(translationValue, 0, 0);

        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        xRot = transform.localEulerAngles.x;
        yRot = transform.localEulerAngles.y;
        zRot = transform.localEulerAngles.z;

        writeTransformPosition();
        writeTransformRotation();
    }

    private void writeTransformPosition()
    {
        using (System.IO.StreamWriter file = new StreamWriter(pathName, true))
        {
            string output = string.Format("X{0} Y{1} Z{2}", xPos, yPos, zPos);

            file.WriteLine(output);
        }
    }

    private void clearPosition()
    {
        using (System.IO.StreamWriter file2 = new StreamWriter(pathName, false))
        {

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

    private void clearRotation()
    {
        using (System.IO.StreamWriter file2 = new StreamWriter(pathName2, false))
        {

        }
    }
}
