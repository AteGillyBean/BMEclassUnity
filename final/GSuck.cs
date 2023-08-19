using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSuck : MonoBehaviour
{
    public GameObject sphere, GCan;
    private float speed = 2;
    private Vector3 zPos;
    bool move;

    void Start()
    {
        zPos = sphere.transform.position; //og position at 5,0,0
        move = true; //movement to left is happening
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sphere.transform.position = zPos;
            move = true;
            sphere.tag = "Untagged";
        }
        if (move == true)
        {
            sphere.GetComponent<Rigidbody>().velocity = Vector3.left * speed * Time.deltaTime;
        }

        if (move == false)
        {
            //make it stop so velocity is none
            sphere.GetComponent<Rigidbody>().velocity = Vector3.zero * speed * Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Virus")
        {
            other.GetComponent<Rigidbody>().AddForce((GCan.transform.position - sphere.transform.position) * 50); //sucks it up

            if (sphere.transform.position.z == GCan.transform.position.z)
            {
                move = false; //stop the left movement
            }
        }
    }
}
