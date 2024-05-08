using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolls : MonoBehaviour
{
    public bool scroll1;
    public bool scroll2;
    public bool scroll3;
    public static bool collect1;
    public static bool collect2;
    public static bool collect3;

   
    public void collect()
    {
        if(scroll1)
        {
            collect1 = true;
            Destroy(this.gameObject);

        }
        else if(scroll2)
        {
            collect2 = true;
            Destroy(this.gameObject);
        }
        else if(scroll3)
        {
            collect3 = true;
            Destroy(this.gameObject);
        }
    }
}
