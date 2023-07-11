using UnityEngine;
using UnityEngine.SceneManagement;

namespace HEXRPG.GUI
{
    public class GameOverScript : MonoBehaviour
    {
        public GameObject _endGamePanel;

        public void ShowGameOverMenu()
        {
            Invoke("GameOverMenu", 2f);
        }

        private void GameOverMenu()
        {
            _endGamePanel.SetActive(true);
        }
        
        public void Restart()
        {
            SceneManager.LoadScene("FirstScene");
        }
    }
}