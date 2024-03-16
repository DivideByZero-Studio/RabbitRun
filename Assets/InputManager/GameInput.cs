using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInput _playerInput;

    public event Action JumpButtonPressed;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();

        SubscribeToEvents();
    }

    private void JumpButton_pressed(InputAction.CallbackContext callbackContext) => JumpButtonPressed?.Invoke();

    private void SubscribeToEvents()
    {
        _playerInput.Player.Jump.started += JumpButton_pressed;
    }
}
