using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool pool;

    public GameObject Bullet; // Prefab de la bala
    [SerializeField] private GameObject SpawnPoint; // Punto inicial de las balas
    [SerializeField] private int initialPoolSize = 10; // Tamaño inicial del pool

    private Stack<GameObject> stack;

    void Start()
    {
        // Configuración del Singleton
        if (BulletPool.pool != null && BulletPool.pool != this)
        {
            Destroy(gameObject);
        }
        BulletPool.pool = this;

        // Inicializa el stack y genera el pool inicial
        stack = new Stack<GameObject>();
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.transform.position, Quaternion.identity);
            obj.SetActive(false);
            stack.Push(obj);
        }
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        stack.Push(obj);
    }

    public GameObject Pop()
    {
        if (stack.Count > 0)
        {
            GameObject obj = stack.Pop();
            obj.SetActive(true);
            obj.transform.position = SpawnPoint.transform.position;
            return obj;
        }
        else
        {
            // Crea una nueva bala si el pool está vacío
            GameObject obj = Instantiate(Bullet, SpawnPoint.transform.position, Quaternion.identity);
            return obj;
        }
    }
}
