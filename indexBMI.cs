using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour
{
    public float rotationVal = 0;
    public float patientWidth;
    public float patientHeight;
    public float BMI;

    public Text bmiText;

    public GameObject rightScanner;
    public GameObject leftScanner;
    RaycastHit hitRightScanner;
    RaycastHit hitLeftScanner;

    // Start is called before the first frame update
    void Start()
    {
        rightScanner = GameObject.FindGameObjectWithTag("rightScanner");
        leftScanner = GameObject.FindGameObjectWithTag("leftScanner");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotationVal = rotationVal + 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationVal));
            if (rotationVal == 360)
            {
                rotationVal = 0;
            }
        }

        if ((rotationVal == 0) || (rotationVal == 180))
        {
            if ((Physics.Raycast(rightScanner.transform.position, rightScanner.transform.TransformDirection(Vector3.up), out hitRightScanner, 5f)) && (Physics.Raycast(leftScanner.transform.position, leftScanner.transform.TransformDirection(Vector3.down), out hitLeftScanner, 5f)))
            {
                float scanDistance = Vector3.Distance(leftScanner.transform.position, rightScanner.transform.position);
                Debug.DrawRay(rightScanner.transform.position, rightScanner.transform.TransformDirection(Vector3.up) * hitRightScanner.distance, Color.red);
                Debug.DrawRay(leftScanner.transform.position, leftScanner.transform.TransformDirection(Vector3.down) * hitLeftScanner.distance, Color.blue);
                
                if ((hitRightScanner.collider.tag == "patient") && (hitLeftScanner.collider.tag == "patient"))
                {
                    patientWidth = scanDistance - (hitRightScanner.distance + hitLeftScanner.distance);
                    Debug.Log("Patient Width: " + patientWidth);
                }
            }
        }

        if ((rotationVal == 90) || (rotationVal == 270))
        {
            if ((Physics.Raycast(rightScanner.transform.position, rightScanner.transform.TransformDirection(Vector3.up), out hitRightScanner, 5f)) && (Physics.Raycast(leftScanner.transform.position, leftScanner.transform.TransformDirection(Vector3.down), out hitLeftScanner, 5f)))
            {
                float scanDistance = Vector3.Distance(leftScanner.transform.position, rightScanner.transform.position);
                Debug.DrawRay(rightScanner.transform.position,rightScanner.transform.TransformDirection(Vector3.up) * hitRightScanner.distance, Color.red);
                Debug.DrawRay(leftScanner.transform.position, leftScanner.transform.TransformDirection(Vector3.down) * hitLeftScanner.distance, Color.blue);
                
                if ((hitRightScanner.collider.tag == "patient") && (hitLeftScanner.collider.tag == "patient"))
                {
                    patientHeight = scanDistance - (hitRightScanner.distance + hitLeftScanner.distance);
                    Debug.Log("Patient Height: " + patientHeight);
                }
            }
        }

        BMI = 1 * patientHeight * patientWidth;
        bmiText.text = "BMI: " + BMI.ToString();
    }
}

