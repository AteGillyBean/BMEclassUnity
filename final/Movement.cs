using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 zPos; //left movement
    public float speed = 5;

    Color[] colors = new Color[3]; //get the colors

    void Start()
    {
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[0] = Color.blue;

        zPos = transform.position;
    }

    //moving in z position
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];

            if (GetComponent<Renderer>().material.color == Color.red)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                transform.Translate(Vector3.left * (0.5f * speed) * Time.deltaTime);
                gameObject.tag = "RBC";
            }

            if (GetComponent<Renderer>().material.color == Color.green)
            {
                transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                transform.Translate(Vector3.left * (0.5f * speed) * Time.deltaTime);
                gameObject.tag = "Virus"; //tag it virus
            }

            if (GetComponent<Renderer>().material.color == Color.blue)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                transform.Translate(Vector3.left * (20f * speed) * Time.deltaTime); //blue goes faster
                gameObject.tag = "Anti";
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = zPos;
        }
    }
}
