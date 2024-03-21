using UnityEngine;

public class GUIController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    [SerializeField] private JumpsView jumpsView;

    private int currentJumpIndex = 2;
    
    private void Start()
    {
        player.JumpReloadStarted += StartedJumpView;
        player.JumpReloadUpdate += UpdateJumpView;
        player.JumpReloadDone += DoneJumpView;
    }

    private void StartedJumpView()
    {
        currentJumpIndex--;
        if (currentJumpIndex < 1)
        {
            jumpsView.SetReloadCleared(currentJumpIndex + 2);
        }
    }

    private void UpdateJumpView(float progress)
    {
        jumpsView.UpdateReloadView(currentJumpIndex+1, progress);
    }

    private void DoneJumpView()
    {
        currentJumpIndex++;
        jumpsView.SetReloadFilled(currentJumpIndex);
    }
}
