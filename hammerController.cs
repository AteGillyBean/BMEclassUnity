using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class hammerController : MonoBehaviour
{
    public float scalar = 10;
    public GameObject reflex;
    public GameObject reflexClone;
    public GameObject obstruction;
    public GameObject[] reflexArray; // for destroy in array, pulls up objects tagged in varibale

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-scalar*Time.deltaTime, 0, 0);
            //Debug.Log(Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(scalar*Time.deltaTime, 0, 0);
            //Debug.Log(Time.deltaTime);
        }
    }
    //private void OnTriggerEnter(Collider other) // used for thresholds, no physics
    //{
    //    Instantiate(reflex);
    //    // Debug.Log("Ouch");
    //}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
            Debug.Log(hit.distance);
            Debug.Log(hit.collider.name);

            if (hit.collider.name == "Cube")
            {
                obstruction = GameObject.Find("Cube");
                Destroy(obstruction);
            }
        }

    }

    private void OnTriggerStay(Collider other) // trigger is used when object has trigger
    {
        reflexClone = Instantiate(reflex);

    }
    private void OnTriggerExit(Collider other)
    {
        reflexArray = GameObject.FindGameObjectsWithTag("reflex");
        foreach (GameObject reflex in reflexArray) // reflex is reflex clones in scene
        
        {
            Destroy(reflex, 1.5f);
        }

    }

    private void OnCollisionEnter(Collision collision) // used when object is assigned a rigid body, not a trigger
    {
        Debug.Log(collision.other.name);
    }

}
