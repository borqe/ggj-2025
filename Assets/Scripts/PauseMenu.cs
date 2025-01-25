using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject gameOverText;

    public void ShowGameOverMenu()
    {
        resumeButton.SetActive(false);
        gameOverText.SetActive(true);
    }

    public void ShowPause()
    {
        resumeButton.SetActive(true);
        gameOverText.SetActive(false);
    }
}
