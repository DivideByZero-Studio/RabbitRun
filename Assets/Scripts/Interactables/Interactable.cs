using System;
using Cinemachine;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private InteractableTriggerArea triggerArea;
    
    public event Action Interacted;

    private void InvokeTriggerEvent()
    {
        Interacted?.Invoke();
    }
    
    private void OnEnable()
    {
        triggerArea.TriggerEntered += InvokeTriggerEvent;
    }
    
    private void OnDisable()
    {
        triggerArea.TriggerEntered -= InvokeTriggerEvent;
    }
}
