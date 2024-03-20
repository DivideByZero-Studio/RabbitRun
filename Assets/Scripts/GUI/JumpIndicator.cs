using System.Collections;
using TMPro;
using UnityEngine;

public class JumpIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    public void Fill()
    {
        text.text = "1";
    }
    
    public void Clear()
    {
        text.text = "0";
    }

    public void SetProgress(float progress)
    {
        text.text = $"{progress:#.##}";
    }
}
