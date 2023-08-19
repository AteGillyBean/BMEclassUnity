using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scannerController : MonoBehaviour
{
    public GameObject Medial_Scanner;
    public GameObject Lateral_Scanner;
    public float Medial_Value;
    public float Lateral_Value;
    public float Patient_Value;
    public Text Patient_Data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patient_Value = (Medial_Value + Lateral_Value) / 2;
        Patient_Data.text = "Patient Width Calculated: " + Patient_Value.ToString();
        
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        {
            if (Physics.Raycast(Medial_Scanner.transform.position, Medial_Scanner.transform.TransformDirection(Vector3.up), out hit, 5f))
            {
                Debug.DrawRay(Medial_Scanner.transform.position, Medial_Scanner.transform.TransformDirection(Vector3.up) * hit.distance, Color.red);
                //Debug.Log(hit.distance);
                Medial_Value = hit.distance;

            }

            if (Physics.Raycast(Lateral_Scanner.transform.position, Lateral_Scanner.transform.TransformDirection(Vector3.down), out hit, 5f))
            {
                Debug.DrawRay(Lateral_Scanner.transform.position, Lateral_Scanner.transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                //Debug.Log(hit.distance);
                Lateral_Value = hit.distance;
            }
        }
    
    }
}
