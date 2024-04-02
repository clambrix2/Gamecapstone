using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikething : MonoBehaviour
{
    private Enemies em;
    void Start()
    {
        em = GetComponent<Enemies>();
    }

   // as i move all the enemies hp and attack damage funtions to the enemies script this is no longer needed. 
}
