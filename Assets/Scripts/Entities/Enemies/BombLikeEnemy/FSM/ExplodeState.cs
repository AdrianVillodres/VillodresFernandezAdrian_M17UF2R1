using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "ExplodeState", menuName = "StatesSO/Explode")]
public class ExplodeState : StatesSO<BombFSM>
{
    public override void OnStateEnter(BombFSM ec)
    {
        AudioManager.audioManager.PlayBoom();
    }

    public override void OnStateExit(BombFSM ec)
    {
    }

    public override void OnStateUpdate(BombFSM ec)
    {
        
    }
}
