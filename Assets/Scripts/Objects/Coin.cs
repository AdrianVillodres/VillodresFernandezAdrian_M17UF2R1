using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Moneda recolectada");
            collision.GetComponent<Character>().AddGold();
            Destroy(gameObject);
        }
    }
}

