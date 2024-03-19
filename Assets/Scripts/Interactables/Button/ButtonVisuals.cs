using UnityEngine;

public class ButtonVisuals : MonoBehaviour
{
    [SerializeField] private GameObject pressedVisuals;
    [SerializeField] private GameObject unpressedVisuals;

    public void SetPressedVisuals()
    {
        pressedVisuals.SetActive(true);
        unpressedVisuals.SetActive(false);
    }

    public void SetUnpressedVisuals()
    {
        pressedVisuals.SetActive(false);
        unpressedVisuals.SetActive(true);
    }
}
