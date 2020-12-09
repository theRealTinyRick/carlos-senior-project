using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.UI.GameMenu
{
    public class GameMenuUI : MonoBehaviour
    {
        [SerializeField]
        private string mainMenuSceneName = "MainMenu";

        [SerializeField]
        private GameObject menuParent;

        private static GameMenuUI instance;
        public static GameMenuUI Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            instance = this;
        }

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
