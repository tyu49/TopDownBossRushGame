using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    private Controls _control;

    private void Awake()
    {
        _control = new Controls();
        _control.Player.Enable();
        _control.Player.SetCallbacks(this);
    }

    private void OnDestroy()
    {
        _control.Disable();
        _control.Dispose();
    }

    public event Action<Vector2> OnDir;
    public event Action OnAttackPressed;
    public event Action OnDashPressed;
    public event Action OnParryPressed;
    public event Action OnInteractPressed;
    public void OnMove(InputAction.CallbackContext context)
    {
        OnDir?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnAttackPressed?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnInteractPressed?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnDashPressed?.Invoke();
    }

    public void OnParry(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnParryPressed?.Invoke();
    }
}
