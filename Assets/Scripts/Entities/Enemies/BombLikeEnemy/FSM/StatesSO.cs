using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatesSO : ScriptableObject
{
    public List<StatesSO> StatesToGo;
    public abstract void OnStateEnter(BombFSM ec);
    public abstract void OnStateUpdate(BombFSM ec);
    public abstract void OnStateExit(BombFSM ec);

}