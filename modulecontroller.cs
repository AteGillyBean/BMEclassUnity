using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class modulecontroller : MonoBehaviour
{

    public GameObject lefthand, righthand;
    public GameObject leftpanel, rightpanel;
    public TMP_Text indentificationtext, distancetext;
    public Button scanbtn, forcebtn, suctionbtn;
    public bool scanbool, forcebool, suctionbool;



    // Start is called before the first frame update
    void Start()
    {

        scanbtn.onClick.AddListener(scanControl);
        forcebtn.onClick.AddListener(forceControl);
        suctionbtn.onClick.AddListener(suctionControl);


    }

    // Update is called once per frame
    void Update()
    {
        leftpanel.transform.parent = lefthand.transform;
        rightpanel.transform.parent = righthand.transform;

    }
    private void scanControl()
    {
        Debug.Log("Scan Button Works");
    }
    private void forceControl()
    {
        Debug.Log("Force Button Works");
    }
    private void suctionControl()
    {
        Debug.Log("Suction Button Works");
    }

}
