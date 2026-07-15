using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
{
    public event Action<float> OnMoveKeyPressed;
    public event Action OnAttackKeyPressed;
    public event Action OnJumpKeyPressed;

    private Controls _controls;
    private Vector2 _mouseScreenPosition;
    private void OnEnable()
    {
        if(_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        if(_controls != null)
        {
            _controls.Player.Disable();
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnAttackKeyPressed?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpKeyPressed?.Invoke();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _mouseScreenPosition = context.ReadValue<Vector2>();
        Debug.Log(_mouseScreenPosition);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float moveDir = context.ReadValue<Vector2>().x;
        OnMoveKeyPressed?.Invoke(moveDir);
    }
}
