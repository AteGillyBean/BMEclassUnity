using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class moduleController : MonoBehaviour
{
    public GameObject leftHand, rightHand;
    public GameObject leftPanel, rightPanel;
    public TMP_Text identificationText, distanceText;
    public Button scanBtn, forceBtn, vacuumBtn;
    public bool scanBool, forceBool, vacuumBool;

    // Start is called before the first frame update
    void Start()
    {
        scanBtn.onClick.AddListener(scanControl);
        forceBtn.onClick.AddListener(forceControl);
        vacuumBtn.onClick.AddListener(vacuumControl);
    }

    // Update is called once per frame
    void Update()
    {
        leftPanel.transform.parent = leftHand.transform;
        rightPanel.transform.parent = rightHand.transform;

        //if (forceControl == true)
        //{
        //    Rigidbody leftPanel = leftPanel.GetComponent<Rigidbody>();

        //    leftPanel.AddForce(0, 0, 10);
        //}
    }

    private void scanControl()
    {
        Debug.Log("Scan Button Activate");

        // Activate specific module
        if (leftPanel.GetComponent<scanControl>() == false)
        {
            leftPanel.AddComponent<scanControl>();
        }

        // Eliminate other modules
        if (leftPanel.GetComponent<forceControl>() == true)
        {
            Destroy(leftPanel.GetComponent<forceControl>());
        }

        if (leftPanel.GetComponent<suctionControl>() == true)
        {
            Destroy(leftPanel.GetComponent<suctionControl>());
        }
    }

    private void forceControl()
    {
        Debug.Log("Force Button Activate");

        if (leftPanel.GetComponent<forceControl>() == false)
        {
            leftPanel.AddComponent<forceControl>();
        }

        if (leftPanel.GetComponent<scanControl>() == true)
        {
            Destroy(leftPanel.GetComponent<scanControl>());
        }

        if (leftPanel.GetComponent<suctionControl>() == true)
        {
            Destroy(leftPanel.GetComponent<suctionControl>());
        }
    }

    private void vacuumControl()
    {
        Debug.Log("Vacuum Button Activate");

        if (leftPanel.GetComponent<suctionControl>() == false)
        {
            leftPanel.AddComponent<suctionControl>();
        }

        if (leftPanel.GetComponent<scanControl>() == true)
        {
            Destroy(leftPanel.GetComponent<scanControl>());
        }

        if (leftPanel.GetComponent<forceControl>() == true)
        {
            Destroy(leftPanel.GetComponent<forceControl>());
        }
    }
}
