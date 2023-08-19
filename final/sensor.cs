using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensor : MonoBehaviour
{
    public GameObject cube, sphere, RedCan, GreenCan; 

    Color[] colors = new Color[3];

    private void Start()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(cube.transform.position, cube.transform.TransformDirection(Vector3.down), out hit))
        {
            //tag respect tag in case movement tags don't work
            if (sphere.GetComponent<Renderer>().material.color == Color.red)
            {
                sphere.tag = "RBC";
            }

            if (sphere.GetComponent<Renderer>().material.color == Color.green)
            {
                sphere.tag = "Virus";
            }

            if (sphere.GetComponent<Renderer>().material.color == Color.blue)
            {
                sphere.tag = "Anti";
            }
        }
        if(sphere.tag == "Anti")
        {
            sphere.GetComponent<Rigidbody>().velocity = Vector3.left * 20 *Time.deltaTime;
        }
    }
}
