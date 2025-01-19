using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] private GameObject SpawnPoint;

    private Stack<GameObject> stack;

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
            GameObject obj = Instantiate(Bullet, SpawnPoint.transform.position, Quaternion.identity);
            return obj;
        }
    }
}
