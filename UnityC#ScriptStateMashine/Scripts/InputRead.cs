using System; // potrzebujemy tego dla Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRead : MonoBehaviour, Controls.IPlayerActions
{
    public bool IsAttacking { get; private set; }
    public bool IsBlocking { get; private set; }
    public bool IsRoll { get; private set; }
    public Vector2 MovementValue { get; private set; }
    public Vector3 MovementVector3 { get; private set; }

    public event Action JumpEvent;
    public event Action RollEvent;
    public event Action TargetEvent;
    public event Action CancelEvent;

    private Controls controls;
    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed) { return; }
        JumpEvent?.Invoke();
    }
    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.performed) { return; }
        RollEvent?.Invoke();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }
        TargetEvent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        CancelEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            IsAttacking = true;

        }
        else if (context.canceled)
        {
            IsAttacking = false;
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsBlocking = true;

        }
        else if (context.canceled)
        {
            IsBlocking = false;
        }
    }
}
