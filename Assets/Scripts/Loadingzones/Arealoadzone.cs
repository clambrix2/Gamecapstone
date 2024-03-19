using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arealoadzone : MonoBehaviour
{
    public GameObject area1;
    public GameObject area2;
    public GameObject cam;
    public float moveingcamx;
    public float moveingcamy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void movecamandload()
    {
        area1.SetActive(false);
        cam.transform.position = new Vector3(moveingcamx, moveingcamy, -10);
        area2.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Loadzone"))
        {
            movecamandload();
        }
    }
}
