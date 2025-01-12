using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGrenadeLauncher : MonoBehaviour
{
    Character character;
    int value = 2;
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
                Debug.Log("Comprar");
                Destroy(gameObject);
            }
        }
    }
}
