using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatesSO<T> : ScriptableObject
{
    public List<StatesSO<T>> StatesToGo;
    public abstract void OnStateEnter(T ec);
    public abstract void OnStateUpdate(T ec);
    public abstract void OnStateExit(T ec);

}