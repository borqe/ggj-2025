using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;
    private static GameManager instance;
    
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private PauseMenu pauseScreen;
    [SerializeField] private GameObject inGameScreen;
    
    private bool isGamePaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        loadingScreen.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        inGameScreen.SetActive(false);
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
            inGameScreen.SetActive(true);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                UnpauseGame();
                isGamePaused = false;
            }
            else
            {
                PauseGame();
                isGamePaused = true;
            }
        }
    }

    public void StartGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("TestScene");
        loadingScreen.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        inGameScreen.SetActive(true);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("Boot");
        loadingScreen.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        inGameScreen.SetActive(false);
    }

    public void PauseGame()
    {
        pauseScreen.gameObject.SetActive(true);
        pauseScreen.ShowPause();
        
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        pauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        PauseGame();
        pauseScreen.ShowGameOverMenu();
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE && !UNITY_EDITOR
        Application.Quit();
#elif UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
