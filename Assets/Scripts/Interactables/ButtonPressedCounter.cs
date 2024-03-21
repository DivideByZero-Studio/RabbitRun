using UnityEngine;

public class ButtonPressedCounter : MonoBehaviour
{
    [SerializeField] private ButtonInteractable[] buttons;
    [SerializeField] private GameObject obstacle;

    public void CheckCondition()
    {
        var counter = 0;
        foreach (var button in buttons)
        {
            if (button.isPressed)
                counter++;
        }

        if (counter == buttons.Length)
            RemoveObstacle();
    }

    private void RemoveObstacle()
    {
        obstacle.SetActive(false);
    }
}
