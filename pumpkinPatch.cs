using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkinPatch : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject pumpkin;
    public float xPos, yPos, zPos;
    public float xPosl, yPosl, zPosl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pumpkin.transform.position = leftHand.transform.position;
        xPos = pumpkin.transform.position.x;
        yPos = pumpkin.transform.position.y;
        zPos = pumpkin.transform.position.z;

        xPosl = leftHand.transform.position.x;
        yPosl = leftHand.transform.position.y;
        zPosl = leftHand.transform.position.z;

        //xPos = xPosl;
    }
}
