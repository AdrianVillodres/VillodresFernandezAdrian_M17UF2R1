using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "StatesSOTurret/IdleTurret")]
public class IdleStateTurret : StatesSO<TurretFSM>
{
    private Animator animator;
    public override void OnStateEnter(TurretFSM ec)
    {
    }

    public override void OnStateExit(TurretFSM ec)
    {
    }

    public override void OnStateUpdate(TurretFSM ec)
    {
    }
}
