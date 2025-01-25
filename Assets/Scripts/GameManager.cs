using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;
    private static GameManager instance;
    
    [SerializeField] private GameObject loadingScreen;

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
    }

    public void StartGame()
    {
        loadingScreen.SetActive(true);
        
        SceneManager.LoadScene("TestScene");
        
        loadingScreen.SetActive(false);
    }
}
