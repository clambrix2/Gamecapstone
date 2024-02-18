using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    public GameObject[] Spells;
    private Spell spell;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int spellcastcheck(KeyCode[] c)
    {
        int count;
        count = 0;
        for (int i = 0; i < Spells.Length; i++)
        {

            spell = Spells[i].GetComponent<Spell>();
            Debug.Log(spell.name);
            if (spell.spellritual[count] == c[count] && count == 0)
            {
                count++;
                Debug.Log("passed first check");
            }
            if (spell.spellritual[count] == c[count] && count == 1)
            {
                count++;
                Debug.Log("passed second check");
            }
            if (spell.spellritual[count] == c[count] && count == 2)
            {

                Debug.Log("passed third check");
                return i;
            }
            else
            {
                count = 0;
            }

        }
        // this is here because the code yell at me for not having it, this should never go off
        return -1;
    }
}
