using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveloading : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.SetActive(true);
    }

}
