using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class tableController : MonoBehaviour
{
    public GameObject surgicalBase;
    ////public Slider rotationSlider;
    ////public float m_MyZ;
    ////public Text Rotation;
    //public float x, y, z;
    public float rotation = 0;
    public float minZRotation = -10;
    public float maxZRotation = 10;

    // Start is called before the first frame update
    void Start()
    {
        surgicalBase = GameObject.FindGameObjectWithTag("surgicalBase");
        surgicalBase.transform.rotation = Quaternion.identity;
    }

        // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    surgicalBase.transform.Rotate(0, 0, 10);
        //    Debug.Log(transform.localEulerAngles);
        //}

        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    surgicalBase.transform.Rotate(0, 0, -10);
        //    Debug.Log(transform.localEulerAngles);
        //}

        //if (surgicalBase.transform.localEulerAngles.z >= 20)
        //{
        //    x = surgicalBase.transform.localEulerAngles.x;
        //    y = surgicalBase.transform.localEulerAngles.x;
        //    z = 20;

        //    surgicalBase.transform.localEulerAngles = new Vector3(x, y, z);
        //}

        //if (surgicalBase.transform.localEulerAngles.z >= 340 && surgicalBase.transform.localEulerAngles.z <= 360)
        //{
        //    x = surgicalBase.transform.localEulerAngles.x;
        //    y = surgicalBase.transform.localEulerAngles.x;
        //    z = 340;

        //    surgicalBase.transform.localEulerAngles = new Vector3(x, y, z);
        //}

        //rotation = Mathf.Clamp(rotation, minZRotation, maxZRotation);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotation);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotation = Mathf.Clamp(rotation, minZRotation, maxZRotation);
            surgicalBase.transform.rotation = Quaternion.Euler(0, 0, 2) * surgicalBase.transform.rotation;
            //Debug.Log(surgicalBase.transform.localEulerAngles);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotation = Mathf.Clamp(rotation, minZRotation, maxZRotation);
            surgicalBase.transform.rotation = Quaternion.Euler(0, 0, -2) * surgicalBase.transform.rotation;
            //Debug.Log(surgicalBase.transform.localEulerAngles);
        }

    }

}
