using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatesSOTurret : ScriptableObject
{
    public List<StatesSOTurret> StatesToGo;
    public abstract void OnStateEnter(TurretFSM ec);
    public abstract void OnStateUpdate(TurretFSM ec);
    public abstract void OnStateExit(TurretFSM ec);

}