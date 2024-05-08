using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Haste : MonoBehaviour
{
    public float timer;
    void Start()
    {
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timertodie();
    }
    public void timertodie()
    {
        timer = timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Playercontroller.haste = true;   
        }
    }
}
