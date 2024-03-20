using System.Globalization;
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

    public void SetReloadProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);
        text.text = $"{progress:#.##}";
    }
}
