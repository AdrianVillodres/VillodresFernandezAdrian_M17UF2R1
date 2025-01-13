using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    private BombFSM bomb;
    private Grenade grenade;
    Animator animator;

    void Start()
    {
        bomb = GetComponent<BombFSM>();
        grenade = GetComponent<Grenade>();
        animator = GetComponent<Animator>();
    }

}
