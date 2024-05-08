using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public bool scrollone;
    public bool scrolltwo;
    public bool scrollthree;
    public bool lever;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scrollone)
        {

        }
        else if(scrolltwo)
        {

        }
        else if (scrollthree)
        {

        }
        else if (lever)
        {

        }
    }
    public void levers()
    {
        GameObject temp = gameObject.GetComponent<Gates>().gates;
        if(Input.GetKeyDown(KeyCode.F))
        {

        }
    }
}
