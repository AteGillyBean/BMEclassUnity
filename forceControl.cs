using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<SphereCollider>() == false)
        {
            SphereCollider scL = gameObject.AddComponent<SphereCollider>() as SphereCollider;
            scL.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(0, 0, 100);
        Debug.Log("Force Activated");
    }

    private void OnTriggerExit(Collider other)
    {
        //other.GetComponent<Rigidbody>().AddForce(0, 0, 10);
        Debug.Log("Force Deactivated");
    }
}
