using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerspawner : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public static bool spawner1;
    public float x;
    public float y;
    public bool spawnerone;
    public bool spawnertwo;
    public bool spawnerthree;
    public bool spawnerfour;
    public bool spawnerfive;
    public bool spawnersix;
    public static bool spawner2;
    public static bool spawner3;
    public static bool spawner4;
    public static bool spawner5;
    public static bool spawner6;
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public static bool firstimespawn;
    
    
    void Start()
    {
        spawn();
        firsttimespawn();
     
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void firsttimespawn()
    {
        if(!firstimespawn && !spawnertwo && !spawnerthree && !spawnerfour && !spawnerfive && !spawnersix)
        {
            Instantiate(player, this.gameObject.transform.position, this.gameObject.transform.rotation);
            firstimespawn = true;
            spawner1 = true;
            Debug.Log("here");
        }
    }
    public void spawn()
    {
        
        if(spawner1 && spawnerone)
        {
            Debug.Log("Firstspawn");
            Instantiate(player,this.gameObject.transform.position + new Vector3(0, 1f, 0), this.gameObject.transform.rotation);
            cammove();
            area2.SetActive(false);
            area1.SetActive(true);
            area3.SetActive(false);
        }
        else if(spawner2 && spawnertwo)
        {
            Debug.Log("secondspawn");
            Instantiate(player, this.gameObject.transform.position + new Vector3 (0,1f,0), this.gameObject.transform.rotation);
            cammove();
            area2.SetActive(false);
            area1.SetActive(true);
            area3.SetActive(false);
        }
        else if(spawner3 && spawnerthree)
            {
            Debug.Log("thridspawn");
            Instantiate(player, this.gameObject.transform.position + new Vector3(0, 1f, 0), this.gameObject.transform.rotation);
                cammove();
            area2.SetActive(true);
            area1.SetActive(false);
            area3.SetActive(false);
            
            }
        else if (spawner4 && spawnerfour)
        {
            Debug.Log("fourthspawn");
            Instantiate(player, this.gameObject.transform.position + new Vector3(0, 1f, 0), this.gameObject.transform.rotation);
            cammove();
            area2.SetActive(true);
            area1.SetActive(false);
            area3.SetActive(false);
        }
        else if(spawner5 && spawnerfive)
        {
            Instantiate(player, this.gameObject.transform.position + new Vector3(0, 1f, 0), this.gameObject.transform.rotation);
            cammove();
            area2.SetActive(false);
            area1.SetActive(false);
            area3.SetActive(true);
        }
        else if(spawner6 &&  spawnersix)
        {
            Instantiate(player, this.gameObject.transform.position + new Vector3(0, 1f, 0), this.gameObject.transform.rotation);
            cammove();
            area2.SetActive(false);
            area1.SetActive(false);
            area3.SetActive(true);
        }
    }
    public void cammove()
    {
        cam.transform.position = new Vector3(x, y, -10);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if (spawnerone)
                {
                    spawner1 = true;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr one set");
                }
                else if (spawnertwo)
                {
                    spawner1 = false;
                    spawner2 = true;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr two set");
                }
                else if (spawnerthree)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = true;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr three set");
                }
                else if(spawnerfour)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = true;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr four set");
                }
                else if (spawnerfive)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = true;
                    spawner6 = false;
                }
                else if (spawnersix)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = true;
                }
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if (spawnerone)
                {
                    spawner1 = true;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr one set");
                }
                else if (spawnertwo)
                {
                    spawner1 = false;
                    spawner2 = true;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr two set");
                }
                else if (spawnerthree)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = true;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr three set");
                }
                else if (spawnerfour)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = true;
                    spawner5 = false;
                    spawner6 = false;
                    Debug.Log("spawenr four set");
                }
                else if(spawnerfive)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = true;
                    spawner6 = false;
                }
                else if(spawnersix)
                {
                    spawner1 = false;
                    spawner2 = false;
                    spawner3 = false;
                    spawner4 = false;
                    spawner5 = false;
                    spawner6 = true;
                }
            }
        }
    }
}
