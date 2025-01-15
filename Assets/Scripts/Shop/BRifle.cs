using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BRifle : MonoBehaviour
{
    public int value = 1;
    private ShopManager shopManager;
    private Character character;

    void Start()
    {
        character = GetComponent<Character>();
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
                    shopManager.riflepurchased = true;
                    Character.character.UpdateGoldText();
                }
                Destroy(gameObject);
                Debug.Log("Rifle comprado.");
            }
            else
            {
                Debug.Log("No hay suficiente oro para comprar el rifle.");
            }
        }
    }
}
