using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    static bool isleft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void leftorright(float input)
    {
        if (input < 0)
        {    
            isleft = true;
            
        }
        else if (input > 0)
        {
            isleft = false;
        }
        
    }
   static public bool getleftorright()
    {
        return isleft;
    }
}
