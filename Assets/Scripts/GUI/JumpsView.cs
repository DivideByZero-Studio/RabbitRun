using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpsView : MonoBehaviour
{
    [SerializeField] private List<JumpIndicator> jumpIndicators;

    private void Awake()
    {
        foreach (var indicator in jumpIndicators)
        {
            indicator.Fill();
        }
    }

    public void UpdateReloadView(int index, float progress)
    {
        jumpIndicators[index].SetProgress(progress);
    }
    
    public void SetReloadFilled(int index)
    {
        jumpIndicators[index].Fill();
    }
    
    public void SetReloadCleared(int index)
    {
        jumpIndicators[index].Clear();
    }
}
