using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private string startingSceneName;

        public void StartGame()
        {
            SceneManager.LoadScene(startingSceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

