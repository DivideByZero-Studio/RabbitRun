using UnityEngine;

public class DirectionPointerVisuals : MonoBehaviour
{
    [SerializeField] private GameObject arrowAvailable;
    [SerializeField] private GameObject arrowNotAvailable;

    public void MakeAvailable()
    {
        arrowAvailable.SetActive(true);
        arrowNotAvailable.SetActive(false);
    }
    
    public void MakeNotAvailable()
    {
        arrowAvailable.SetActive(false);
        arrowNotAvailable.SetActive(true);
    }
}
