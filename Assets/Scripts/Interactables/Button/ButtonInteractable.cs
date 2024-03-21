using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class ButtonInteractable : MonoBehaviour
{
    [SerializeField] private ButtonVisuals visuals;
    
    private Interactable _interactable;
    public UnityEvent ButtonPressed;

    public bool isPressed { get; private set; }

    private void Start()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.Interacted += ButtonInteracted;
    }

    public void SetPressed()
    {
        isPressed = true;
        visuals.SetPressedVisuals();
    }
    
    public void SetUnpressed()
    {
        isPressed = false;
        visuals.SetUnpressedVisuals();
    }
    
    private void ButtonInteracted()
    {
        if (isPressed) return;
        SetPressed();
        
        ButtonPressed?.Invoke();
    }
}
