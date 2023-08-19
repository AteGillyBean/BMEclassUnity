using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fingerController : MonoBehaviour
{
    public GameObject mcpJoint;
    public GameObject endEffector;
    public GameObject Saw;
    public Slider abductionSlider;
    public float abductionSliderVal;
    public float xRot, yRot; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        abductionSliderVal = abductionSlider.value;
        xRot = mcpJoint.transform.localEulerAngles.x;
        yRot = mcpJoint.transform.localEulerAngles.y;
        mcpJoint.transform.localEulerAngles = new Vector3(xRot, yRot, abductionSliderVal);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            mcpJoint.transform.Rotate(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            mcpJoint.transform.Rotate(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            mcpJoint.transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mcpJoint.transform.Rotate(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            endEffector.transform.Rotate(0, 1, 0);
        }

    }
}
