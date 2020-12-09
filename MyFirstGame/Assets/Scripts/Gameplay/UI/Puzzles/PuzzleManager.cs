using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI.Puzzles
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField]
        private Puzzle[] puzzles;
        
        private static PuzzleManager instance;
        public static PuzzleManager Instance
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

        public void StartPuzzle(string puzzleName)
        {
            foreach (Puzzle _gameObject in puzzles)
            {
                if(_gameObject.name == puzzleName)
                {
                    _gameObject.gameObject.SetActive(true);
                    return;
                }
            }

            Debug.LogError("No Puzzle found with the name: " + puzzleName);
        }

        public void StopPuzzle(string puzzleName)
        {
            foreach (Puzzle _gameObject in puzzles)
            {
                if (_gameObject.name == puzzleName)
                {
                    _gameObject.gameObject.SetActive(false);
                    return;
                }
            }

            Debug.LogError("No Puzzle found with the name: " + puzzleName);
        }
    }
}
