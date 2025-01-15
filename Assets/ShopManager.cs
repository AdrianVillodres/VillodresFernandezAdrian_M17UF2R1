using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public bool riflepurchased = false;
    public bool grenadepurchased = false;
    public bool flamepurchased = false;

    public Character character;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*        if(riflepurchased == true)
        {
            character.RemoveGold(1);
        }
        else if(grenadepurchased == true)
        {
            character.RemoveGold(2);
        }
        else if (flamepurchased == true)
        {
            character.RemoveGold(3);
        }*/
    //sacar del update todo el if y crear algo para que no este todo el rato actualizando el oro
}
