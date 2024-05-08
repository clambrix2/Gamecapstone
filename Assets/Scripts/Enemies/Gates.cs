using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public GameObject gates;
    public GameObject theboss;
    public float timer;
    public bool timerset;
    public bool boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onbossdeath();
        atzero();
    }
    public void onbossdeath()
    {
        if (Enemies.firstbosskilled || Enemies.secondbosskilled || Enemies.thirdbosskilled)
        {
            gates.SetActive(false);
        }
    }
    public void atzero()
    {
        if (timerset && gates.activeInHierarchy == true)
        {
            if (timer <= 0)
            {
                gates.SetActive(false);
                timerset = false;
            }
            else
            {
                timer = timer - Time.deltaTime;
            }
        }
    }
    public void onuse()
    {
        if(boss || timerset)
        {
            gates.SetActive(true);
        }
        else
        {
            gates.SetActive(false);
        }
            
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            onuse();
        }
    }
}
