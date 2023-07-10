using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject menuPanel;
    private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private void PauseGame()
    {
        menuPanel.SetActive(true); // Показываем меню
        Time.timeScale = 0f; // Замораживаем время в игре
        isPaused = true;
    }

    public void ResumeGame()
    {
        menuPanel.SetActive(false); // Скрываем меню
        Time.timeScale = 1f; // Возобновляем время в игре
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}