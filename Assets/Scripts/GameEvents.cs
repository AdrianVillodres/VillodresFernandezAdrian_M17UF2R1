using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public event Action OnKeyCollected;

    public void KeyCollected()
    {
        OnKeyCollected?.Invoke();
    }

    public event Action<int, Action> OnDoorInteracted;

    public void DoorInteracted(int keysRequired, Action onSuccess)
    {
        OnDoorInteracted?.Invoke(keysRequired, onSuccess);
    }
}
