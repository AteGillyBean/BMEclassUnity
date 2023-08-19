using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scanControl : MonoBehaviour
{
    public GameObject myScanner;
    public string objectIdentification;
    public float objectDistance;
    public GameObject gameID, distanceVal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myScanner == null)
        {
            myScanner = GameObject.FindGameObjectWithTag("panelL");
        }

        gameID = GameObject.Find("identificationValue");
        gameID.GetComponent<Text>().text = objectIdentification;

        distanceVal = GameObject.Find("distanceValue");
        distanceVal.GetComponent<Text>().text = objectDistance.ToString();

    }

    private void FixedUpdate()
    {
        RaycastHit hitR;

        if (Physics.Raycast(myScanner.transform.position, myScanner.transform.TransformDirection(Vector3.down), out hitR, 5f))
        {
            Debug.DrawRay(myScanner.transform.position, myScanner.transform.TransformDirection(Vector3.down) * hitR.distance, Color.red);
        }

        if (hitR.collider == true)
        {
            objectDistance = hitR.distance;

            objectIdentification = hitR.collider.name;
        }
        
        else
        {
            objectIdentification = "No Object Detected";
        }
        
    }
}
