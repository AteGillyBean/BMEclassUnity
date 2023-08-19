using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class positioninfo : MonoBehaviour { 

    public GameObject purpleCube;
    public GameObject greenSphere;
    public GameObject orangeCapsule;

    // Start is called before the first frame update
    void Start() {
        
            //Debug.Log("Position X: " = transform.position.x); to monitor and control position
            //transform.position = new Vector3(2, 2, 2); for position
            //transform.Translate(2, 2, 2); for movement

            purpleCube = GameObject.FindGameObjectWithTag("Purple");
            greenSphere = GameObject.FindGameObjectWithTag("Green");
            orangeCapsule = GameObject.FindGameObjectWithTag("OrangeCap");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            transform.Translate(0, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            transform.Translate(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            transform.Translate(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            purpleCube.transform.Translate(1, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        orangeCapsule = GameObject.FindGameObjectWithTag("OrangeCap");
        orangeCapsule.transform.Translate(-1, 0, 0);

    }


 }
