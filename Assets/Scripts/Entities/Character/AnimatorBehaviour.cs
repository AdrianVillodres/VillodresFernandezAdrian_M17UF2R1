using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorBehaviour : MonoBehaviour
{
    private Animator animator;
    private InputManager inputManager;
    void Start()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("X", inputManager.ipMove.x);
        animator.SetFloat("Y", inputManager.ipMove.y);

        if (inputManager.ipMove.x == 0 && inputManager.ipMove.y == 0)
        {
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }
    }
}
