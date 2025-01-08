using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFlamethrower : MonoBehaviour
{
    Character character;
    int value = 40;
    public bool purchased = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Character.character.gold >= value)
            {
                Character.character.gold = Character.character.gold - value;
                Destroy(gameObject);
                purchased = true;
                Debug.Log("Comprar");
            }
        }
    }
}
