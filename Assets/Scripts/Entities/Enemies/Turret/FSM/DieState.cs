using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "DieState", menuName = "StatesSOTurret/Die")]
public class DieState : StatesSO<TurretFSM>
{
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
