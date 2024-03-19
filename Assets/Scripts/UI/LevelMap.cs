using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMap : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;

    private void Awake()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < unlockedLevels)
                buttons[i].interactable = true;
            else
                buttons[i].interactable = false;
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneLoader.LoadScene(sceneName);
    }
}
