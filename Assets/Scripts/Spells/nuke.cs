using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuke : MonoBehaviour
{
    private float life;
    public Animation animeation;
    void Start()
    {
        life = 1;
        animeation = GetComponent<Animation>();
        animeation.Play("explostion");
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
