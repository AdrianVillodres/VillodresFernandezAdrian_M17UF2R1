using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGrenadeLauncher : MonoBehaviour
{
    public int value = 2;
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
                Character.character.UpdateGoldText();
                if (shopManager != null)
                {
                    shopManager.grenadepurchased = true;
                }
                Destroy(gameObject);
                Debug.Log("Lanzagranadas comprado.");
            }
            else
            {
                Debug.Log("No hay suficiente oro para comprar el Lanzagranadas.");
            }
        }
    }
}
