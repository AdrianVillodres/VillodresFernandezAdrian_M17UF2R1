using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]
public class ChaseState : StatesSO<BombFSM>
{

    public override void OnStateEnter(BombFSM ec)
    {
    }

    public override void OnStateExit(BombFSM ec)
    {
        ec.GetComponent<ChaseBehaviour>().StopChasing();
    }

    public override void OnStateUpdate(BombFSM ec)
    {
        ec.GetComponent<ChaseBehaviour>().Chase(ec.target.transform, ec.transform);
    }
}
