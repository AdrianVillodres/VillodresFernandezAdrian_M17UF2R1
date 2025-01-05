using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    public static Character character;
    private Animator animator;
    private Inventory inventory;

    [Header("Atributos")]
    public float speed;
    public int HP = 5;
    public int gold = 0;
    public int keys = 0;


    [Header("UI Elementos")]
    public Slider healthSlider;
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Keys;

    void Start()
    {
        if (character == null)
        {
            character = this;
            DontDestroyOnLoad(gameObject);
            animator = GetComponent<Animator>();
            inventory = GetComponent<Inventory>();

            if (GameEvents.instance != null)
            {
                GameEvents.instance.OnDoorInteracted += CheckKeysForDoor;
            }


            if (healthSlider != null)
            {
                healthSlider.maxValue = 5;
                healthSlider.minValue = 0;
                healthSlider.value = HP;
            }


            UpdateGoldText();
            UpdateKeysText();

        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnDestroy()
    {
        if (GameEvents.instance != null)
        {
            GameEvents.instance.OnDoorInteracted -= CheckKeysForDoor;
        }
    }

    public void AddGold()
    {
        gold++;
        UpdateGoldText();
        Debug.Log("Oro actual: " + gold);
    }

    public void AddKey()
    {
        keys++;
        UpdateKeysText();
        Debug.Log("Llaves actuales: " + keys);
    }

    private void CheckKeysForDoor(int keysRequired, Action onSuccess)
    {
        if (keys >= keysRequired)
        {
            keys -= keysRequired;
            UpdateKeysText();
            Debug.Log($"Puerta abierta, llaves restantes: {keys}");
            onSuccess?.Invoke();
        }
        else
        {
            Debug.Log("No tienes suficientes llaves.");
        }
    }

    public void CheckIfAlive()
    {
        if (HP < 1)
        {
            animator.SetBool("Die", true);
            Debug.Log("El personaje ha muerto.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
            UpdateHealthBar();
            CheckIfAlive();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = HP;
        }
    }

    private void UpdateGoldText()
    {
        if (Gold != null)
        {
            Gold.text = "Oro: " + gold;
        }
    }

    private void UpdateKeysText()
    {
        if (Keys != null)
        {
            Keys.text = "Llaves: " + keys;
        }
    }
}
