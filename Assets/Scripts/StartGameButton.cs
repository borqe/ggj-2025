using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
}
