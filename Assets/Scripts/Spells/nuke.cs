using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuke : MonoBehaviour
{
    private float life;
    void Start()
    {
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            life -= Time.deltaTime;

        }
    }
   
}
