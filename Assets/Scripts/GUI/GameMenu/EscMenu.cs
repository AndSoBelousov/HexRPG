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
        menuPanel.SetActive(true); // ���������� ����
        Time.timeScale = 0f; // ������������ ����� � ����
        isPaused = true;
    }

    public void ResumeGame()
    {
        menuPanel.SetActive(false); // �������� ����
        Time.timeScale = 1f; // ������������ ����� � ����
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}