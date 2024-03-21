using UnityEngine;

public class LevelEndCheckpoint : MonoBehaviour
{
    [SerializeField] private int currentLevelIndex;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            PlayerPrefs.SetInt("UnlockedLevels", currentLevelIndex + 1);
            SceneLoader.LoadScene("LevelChoice");
        }
    }
}
