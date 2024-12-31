using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character character;
    private Animator animator;

    [Header("Atributos")]
    public float speed;
    public int HP;
    public int gold = 0;
    public int keys = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (character == null)
        {
            character = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (GameEvents.instance != null)
        {
            GameEvents.instance.OnDoorInteracted += CheckKeysForDoor;
        }
    }

    private void OnDestroy()
    {
        if (GameEvents.instance != null)
        {
            GameEvents.instance.OnDoorInteracted -= CheckKeysForDoor;
        }
    }

    void Update()
    {

    }

    public void AddGold()
    {
        gold++;
        Debug.Log("Oro actual: " + gold);
    }

    public void AddKey()
    {
        keys++;
        Debug.Log("Llaves actuales: " + keys);
    }

    private void CheckKeysForDoor(int keysRequired, Action onSuccess)
    {
        if (keys >= keysRequired)
        {
            keys -= keysRequired;
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
            CheckIfAlive();
        }
    }
}
