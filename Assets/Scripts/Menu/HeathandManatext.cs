using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeathandManatext : MonoBehaviour
{
    public bool health;
    public bool mana;
    public  TMP_Text text;
 
    // Update is called once per frame
    void Update()
    {
        setheathormana();
    }
    private void setheathormana()
    {
        if (mana)
        {
            text.text = PlayerHealthandMana.Mana + ":50";
        }
        else if(health)
        {
            text.text = PlayerHealthandMana.health + ":50";
        }
    }
}
