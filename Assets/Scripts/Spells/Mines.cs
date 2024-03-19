using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    public float live;
    void Start()
    {
        if(live == 0)
        {
            live = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(live <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            live -= Time.deltaTime;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("Here");
        }
    }
}
