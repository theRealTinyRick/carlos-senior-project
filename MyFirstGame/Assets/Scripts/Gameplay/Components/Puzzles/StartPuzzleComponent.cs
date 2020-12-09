using UnityEngine;

namespace Gameplay.UI.Puzzles
{
    public class StartPuzzleComponent : MonoBehaviour
    {
        [SerializeField]
        private string puzzleName = "";

        private bool startPuzzleOnGameStart = false;

        private void Awake()
        {
            if(startPuzzleOnGameStart)
            {
                StartPuzzle();
            }
        }

        public void StartPuzzle()
        {
            if(PuzzleManager.Instance != null)
            {
                PuzzleManager.Instance.StartPuzzle(puzzleName);
            }
        }

        public void StopPuzzle()
        {
            if (PuzzleManager.Instance != null)
            {
                PuzzleManager.Instance.StopPuzzle(puzzleName);
            }
        }
    }
}
