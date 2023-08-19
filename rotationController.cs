using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class rotationController : MonoBehaviour
{
    public GameObject rotationScanner;
    public GameObject target;
    //public Transform objectToRotateAround;

    // Start is called before the first frame update
    void Start()
    {
        rotationScanner = GameObject.FindGameObjectWithTag("rotationScanner");
        //rotationScanner.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotationScanner.transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), 90);
            //rotationScanner.transform.RotateAround(objectToRotateAround.position, Vector3.up, 90);

        }

    }

}
