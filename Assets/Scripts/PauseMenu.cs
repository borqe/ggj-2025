using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject gameWinText;
    
    public void ShowGameOverMenu()
    {
        gameWinText.SetActive(false);
        resumeButton.SetActive(false);
        gameOverText.SetActive(true);
    }

    public void ShowPause()
    {
        resumeButton.SetActive(true);
        gameOverText.SetActive(false);
        gameWinText.SetActive(false);
    }

    public void ShowGameWinMenu()
    {
        gameOverText.SetActive(false);
        resumeButton.SetActive(false);
        gameWinText.SetActive(true);
    }
}
