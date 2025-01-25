using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;
    private static GameManager instance;
    
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject pauseScreen;
    
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
        pauseScreen.SetActive(false);
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
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("Boot");
        loadingScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
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
