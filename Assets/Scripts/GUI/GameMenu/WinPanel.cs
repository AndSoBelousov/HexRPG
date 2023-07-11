using UnityEngine;
using UnityEngine.SceneManagement;

namespace HEXRPG.GUI
{
    public class WinPanel : MonoBehaviour
    {
        public GameObject _winPanel;

        public void ShowWinPanel()
        {
            Invoke("WinMenu", 4f);
        }

        private void WinMenu()
        {
            _winPanel.SetActive(true);
        }
        
        public void Restart()
        {
            SceneManager.LoadScene("FirstScene");
        }
    }
}