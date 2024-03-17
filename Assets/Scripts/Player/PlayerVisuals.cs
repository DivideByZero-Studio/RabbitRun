using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private List<GameObject> visuals;

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}
