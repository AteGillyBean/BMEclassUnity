using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(90, 0, 0);
        //Debug.Log("Rotation X: " + transform.localEulerAngles);

        if(Input.GetKeyDown(KeyCode.F1))
        {
            transform.Rotate(90, 0, 0);
        }
    }
}
