using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveElbow : MonoBehaviour
{
    public float abduction = 0f;
    public float adduction = 0f;
    public float flexion = 0f;
    public float extension = 0f;
    public float positiveRoll = 0f;
    public float negativeRoll = 0f;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Rotate(0, -45, 0);
            transform.Rotate(0, abduction, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.Rotate(0, 45, 0);
            transform.Rotate(0, adduction, 0);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.Rotate(0, -45, 0);
            transform.Rotate(0, flexion, 0);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.Rotate(0, -45, 0);
            transform.Rotate(0, extension, 0);
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            //transform.Rotate(0, -45, 0);
            transform.Rotate(0, positiveRoll, 0);
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            //transform.Rotate(0, -45, 0);
            transform.Rotate(0, negativeRoll, 0);
        }
    }
}
