using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanControl : MonoBehaviour
{
    public GameObject myscanner;
    public string objectidentification;
    public float objectdistance;
    public GameObject gameID, distanceVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myscanner == null)
        {
            myscanner = GameObject.FindGameObjectWithTag("PanelL");
        }
        gameID = GameObject.Find("IdentificationValue");
        gameID = GetComponent<Text>().text = objectidentification;
        distanceVal = GameObject.Find("distanceVal");

        distanceVal = GetComponent<Text>().text = objectdistance.ToString();
    }
    private void FixedUpdate()
    {
        RaycastHit HitR;
            if (Physics.Raycast(myscanner.transform.position, myscanner.transform.TransformDirection(Vector3.down), out HitR, 5f));
            {
            Debug.DrawRay(myscanner.transform.position, myscanner.transform.TransformDirection(Vector3.down), out HitR, 5f);
            }
    }
}
