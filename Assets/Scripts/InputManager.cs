using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerInputs.IPlayerActions
{
    [SerializeField] private float speed;
    private PlayerInputs playerInput;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 ipMove;
    void Awake()
    {
        playerInput = new PlayerInputs();
        playerInput.Player.SetCallbacks(this);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime * ipMove.normalized);
        animator.SetFloat("X", ipMove.x);
        animator.SetFloat("Y", ipMove.y);
    }

    // Update is called once per frame
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        ipMove = context.ReadValue<Vector2>();
    }
}
