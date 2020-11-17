using UnityEngine;
using UnityEngine.SceneManagement;

namespace CSP.UI.GameMenu
{
    public class GameMenuUI : MonoBehaviour
    {
        [SerializeField]
        private string mainMenuSceneName = "MainMenu";

        [SerializeField]
        private GameObject menuParent;

        public void OpenMenu()
        {
            if(menuParent != null)
            {
                menuParent.SetActive(true);
            }
        }

        public void CloseMenu()
        {
            if(menuParent != null)
            {
                menuParent.SetActive(false);
            }
        }

        public void ToggleMenu()
        {
            if (menuParent != null)
            {
                menuParent.SetActive(!menuParent.activeSelf);
            }
        }

        public void ExitToMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
