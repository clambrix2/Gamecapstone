using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Darkorbs : MonoBehaviour
{
    public int counter;
    public float cooldown;
    public GameObject darkorbs;
    public Transform shootpoint;
    void Start()
    {
        counter = 0;
        cooldown = (float).5;
    }

    // Update is called once per frame
    void Update()
    {
        darkorbsluncher();
    }
    private void darkorbsluncher()
    {
        if(counter <= 5 && cooldown <= 0)
        {
            Instantiate(darkorbs, shootpoint.position, shootpoint.rotation);
            counter++;
            cooldown = (float).5;
        }
        else if(counter == 5)
        {
            Destroy(this.gameObject);
        }
        else
        {
            cooldown = cooldown - Time.deltaTime;
        }
    }
    
}
