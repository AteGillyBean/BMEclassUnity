using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {
        if (gameObject.GetComponent<SphereCollider>() == false)
        {
            SphereCollider scl = gameObject.AddComponent<SphereCollider>() as SphereCollider;
            scl.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Force Activated");
        other.GetComponent<Rigidbody>().AddForce(0, 0, 10);
       
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Force Deactivated");
    }
}
