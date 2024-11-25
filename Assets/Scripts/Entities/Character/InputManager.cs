using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, Inputs.IPlayerActions
{
    private Inputs playerInput;
    private Rigidbody2D rb;
    public Vector2 ipMove;
    private Character character;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = new Inputs();
        playerInput.Player.SetCallbacks(this);
        character = GetComponent<Character>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + character.speed * Time.deltaTime * ipMove.normalized);
    }

    public void Update()
    {
        
    }

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
