using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFlamethrower : MonoBehaviour
{
    public int value = 3;
    private ShopManager shopManager;

    void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        if (shopManager == null)
        {
            Debug.LogError("No se encontró ShopManager en la escena.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Character.character.gold >= value)
            {
                Character.character.gold -= value;
                if (shopManager != null)
                {
                    shopManager.flamepurchased = true;
                }
                Destroy(gameObject);
                Debug.Log("Lanzallamas comprado.");
            }
            else
            {
                Debug.Log("No hay suficiente oro para comprar el Lanzallamas.");
            }
        }
    }
}
