using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeHolderCode : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Color sphereColor = sphere.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = sphereColor;
        }
    }
}
