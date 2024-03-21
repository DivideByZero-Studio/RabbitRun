using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private const string JumpForward = "JumpForward";
    private const string JumpRight = "JumpRight";
    private const string JumpBack = "JumpBack";
    private const string JumpLeft = "JumpLeft";

    public void SetRotation(Quaternion rotation)
    {
        var angle = rotation.eulerAngles.z;
        
        if (angle > 45 && angle < 135)
            animator.SetTrigger(JumpForward);
        else if (angle > 135 && angle < 225)
            animator.SetTrigger(JumpLeft);
        else if (angle > 225 && angle < 315)
            animator.SetTrigger(JumpBack);
        else
            animator.SetTrigger(JumpRight);
    }
}
