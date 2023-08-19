using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{
    public GameObject Particle, RCan, GCan, Controller; 
    public Text RText, GText, BText, RVolText, GVolText; 
    public Button RVol, GVol;
    public int RCount, GCount, BCount, OptionSize, SizeLimit;
    public float RVolCount, GVolCount;
    public CanSize sizer; //from empty game object cansize

    float downHitR, upHitR, downHitG, upHitG;
    float Rvol, Gvol, CanDistance;
    void Start()
    {
        sizer = Controller.GetComponent<CanSize>();
        RCount = 0;
        RText.text = "Red Blood Cells: " + RCount.ToString();
        GCount = 0;
        GText.text = "Virus Count: " + GCount.ToString();
        BCount = 0;
        BText.text = "Antibiotic Count: " + BCount.ToString();
        GVolCount = 0;
        GVolText.text = "Virus Volume: " + GVolCount.ToString();
        RVolCount = 0;
        RVolText.text = "RBC Volume: " + RVolCount.ToString();
    }
    void OnEnable() // Enable Buttons on click
    {
        RVol.onClick.AddListener(() => OnButton(RVol));
        GVol.onClick.AddListener(() => OnButton(GVol));
    }

    void Update()
    {
        OptionSize = sizer.OptionSize; 
        if (OptionSize == 0)
        {
            SizeLimit = 2; //limit 2
        }
        if (OptionSize == 1)
        {
            SizeLimit = 4; //limit 4
        }
        if (OptionSize == 2)
        {
            SizeLimit = 8; //limit 8
        }
        RaycastHit hit;
        if (Physics.Raycast(RCan.transform.position, RCan.transform.TransformDirection(Vector3.down), out hit))
        {
            if (hit.collider.gameObject.CompareTag("RBC"))
            {
                downHitR = hit.distance;
            }

            else if (hit.collider.gameObject.CompareTag("Virus"))
            {
                downHitG = hit.distance;
            }
        }
        if (Physics.Raycast(GCan.transform.position, RCan.transform.TransformDirection(Vector3.up), out hit))
        {
            if (hit.collider.gameObject.CompareTag("RBC"))
            {
                upHitR = hit.distance;
            }

            else if (hit.collider.gameObject.CompareTag("Virus"))
            {
                upHitG = hit.distance;
            }
        }
        Rvol = (upHitR - downHitR)/2 * (upHitR - downHitR)/2 * (upHitR - downHitR)/2;
        //Rvol = 4/3 * ((upHitR - downHitR) / 2) * 3.14f;
        //Rvol = (CanDistance - (upHitR + downHitR)) * 3;
        Gvol = (downHitG - upHitG)/2 * (downHitG - upHitG)/2 * (downHitG - upHitG)/2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RBC")
        {
            if (RCount < SizeLimit)
            {
                RCount += 1;
                RText.text = "Red Blood Cells: " + RCount.ToString();
            }
        }
        if (other.tag == "Virus")
        {
            if (GCount < SizeLimit)
            {
                GCount += 1;
                GText.text = "Virus Count: " + GCount.ToString();
            }
        }
        if (other.tag == "Anti")
        {
            BCount += 1;
            BText.text = "Antibiotic Count: " + BCount.ToString();
        }
    }
    public void OnButton(Button buttonPressed)
    {
        if (buttonPressed == RVol)
        {
            RVolText.text = "RBC Volume: " + (RCount * Rvol).ToString();
        }
        if (buttonPressed == GVol)
        {
            GVolText.text = "Virus Volume: " + (GCount * Gvol).ToString();
        }
    }
}
