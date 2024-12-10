using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePool : MonoBehaviour
{
    public static GrenadePool pool;

    public GameObject Grenade;
    [SerializeField] private GameObject SpawnPoint;

    private Stack<GameObject> stack;

    void Start()
    {
        if (GrenadePool.pool != null && GrenadePool.pool != this)
        {
            Destroy(gameObject);
        }
        GrenadePool.pool = this;


        stack = new Stack<GameObject>();

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
            GameObject obj = Instantiate(Grenade, SpawnPoint.transform.position, Quaternion.identity);
            return obj;
        }
    }
}
