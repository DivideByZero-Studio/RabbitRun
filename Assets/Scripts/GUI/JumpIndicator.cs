using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpIndicator : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite clearSprite;
    [SerializeField] private List<Sprite> fillSprites;
        
    public void Fill()
    {
        image.sprite = fillSprites[7];
    }
    
    public void Clear()
    {
        image.sprite = clearSprite;
    }

    public void SetProgress(float progress)
    {
        if (progress < 0.125f)
            image.sprite = fillSprites[0];
        else if (progress < 0.25f)
            image.sprite = fillSprites[1];
        else if (progress < 0.375f)
            image.sprite = fillSprites[2];
        else if (progress < 0.5f)
            image.sprite = fillSprites[3];
        else if (progress < 0.625f)
            image.sprite = fillSprites[4];
        else if (progress < 0.75f)
            image.sprite = fillSprites[5];
        else if (progress < 0.875f)
            image.sprite = fillSprites[6];
        else if (progress < 1f)
            image.sprite = fillSprites[7];
    }
}
