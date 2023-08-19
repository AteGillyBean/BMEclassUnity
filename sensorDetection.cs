using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorDetection : MonoBehaviour
{

    public float scaleForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit; //LiDAR
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);

                if (hit.collider!= null)
                {
                    Debug.Log(hit.collider.name);
                    Debug.Log(hit.distance);

                }
             }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        other.GetComponent<Rigidbody>().AddForce(0, -scaleForce, 0); //vaccum 
    }
}
