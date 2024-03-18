using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class Button : MonoBehaviour
{
    private Interactable _interactable;
    public UnityEvent ButtonPressed;

    private bool _isPressed;

    private void Start()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.Interacted += ButtonInteracted;
    }

    private void ButtonInteracted()
    {
        if (_isPressed) return;
        _isPressed = true;
        
        ButtonPressed?.Invoke();
    }
}
