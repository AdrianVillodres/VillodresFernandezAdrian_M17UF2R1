using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFlamethrower : MonoBehaviour
{
    public int value = 3;
    private ShopManager shopManager;
    private Inventory inventory;

    void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        inventory = Character.character.GetComponent<Inventory>();
        if (shopManager == null)
        {
            Debug.LogError("No se encontró ShopManager en la escena.");
        }
        if(inventory.flamepurchased == true)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Character.character.gold >= value)
            {
                Character.character.gold -= value;
                Character.character.UpdateGoldText();
                if (shopManager != null)
                {
                    inventory.flamepurchased = true;
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
