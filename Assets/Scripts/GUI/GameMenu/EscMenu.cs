using UnityEngine;
using UnityEngine.SceneManagement;

namespace HEXRPG.GUI
{
    public class EscMenu : MonoBehaviour
    {
        public GameObject menuPanel;
        private bool isPaused;

        // ��� ������� Esc � ���� ��������� ����, ��� ��������� ������� ���������.
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    PauseGame();
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (isPaused)
                    {
                        ResumeGame();
                    }
                }
            }
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");//�������� ����� �������� ����
        }

        private void PauseGame()
        {
            menuPanel.SetActive(true); //���������� ����
            isPaused = true;
        }

        public void ResumeGame()
        {
            menuPanel.SetActive(false); //�������� ����
            isPaused = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}