using UnityEngine;
using UnityEngine.SceneManagement;

namespace HEXRPG.GUI
{
    public class EscMenu : MonoBehaviour
    {
        public GameObject menuPanel;
        private bool isPaused;

        // При нажатии Esc в игре откроется меню, при повторном нажатии закроется.
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
            SceneManager.LoadScene("MainMenu");//загрузка сцены главного меню
        }

        private void PauseGame()
        {
            menuPanel.SetActive(true); //показываем меню
            isPaused = true;
        }

        public void ResumeGame()
        {
            menuPanel.SetActive(false); //скрываем меню
            isPaused = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}