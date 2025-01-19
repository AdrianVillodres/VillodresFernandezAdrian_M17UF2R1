using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePool : MonoBehaviour
{
    public GameObject Grenade;
    [SerializeField] private GameObject SpawnPoint;

    public Stack<GameObject> stack;

    void Start()
    {
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

    public void ClearGrenadePool()
    {
        stack.Clear();
    }

}
