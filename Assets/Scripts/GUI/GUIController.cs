using UnityEngine;

public class GUIController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    [SerializeField] private JumpsView jumpsView;
    
    private void Start()
    {
        player.JumpBeganReload += UpdateJumpView;
    }

    private void UpdateJumpView(float reloadTime)
    {
        jumpsView.StartReloadView(reloadTime);
    }
}
