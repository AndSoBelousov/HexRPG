using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void QuitGame()
    {
        Debug.Log("����� �� ����.");
        Application.Quit();
    }
}
