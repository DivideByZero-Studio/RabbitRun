using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class ButtonInteractable : MonoBehaviour
{
    private Interactable _interactable;
    public UnityEvent ButtonPressed;

    private bool _isPressed;

    [SerializeField] private AudioClip _interactionSFX;

    private void Start()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.Interacted += ButtonInteracted;
    }

    private void ButtonInteracted()
    {
        if (_isPressed) return;
        _isPressed = true;
        PlaySFX();
        ButtonPressed?.Invoke();
    }

    private void PlaySFX()
    {
        AudioManager.Instance.PlaySFX(_interactionSFX);
    }
}
