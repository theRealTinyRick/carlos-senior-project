using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI.Puzzles
{
    [System.Serializable]
    public class MatchingPuzzleEvent : UnityEngine.Events.UnityEvent { }

    public class MatchingPuzzle : Puzzle
    {
        [SerializeField]
        private List<Tile> tiles = new List<Tile>();
        
        [SerializeField]
        private List<MatchingTile> matchingTiles = new List<MatchingTile>();

        [SerializeField]
        private float resetDelay = 0.5f;

        [SerializeField]
        public MatchingPuzzleEvent puzzleStartedEvent = new MatchingPuzzleEvent();
        
        [SerializeField]
        public MatchingPuzzleEvent puzzleEndedEvent = new MatchingPuzzleEvent();
        
        [SerializeField]
        public MatchingPuzzleEvent puzzleSuccessEvent = new MatchingPuzzleEvent();

        private List<MatchingTile> correctTiles = new List<MatchingTile>();
        private MatchingTile currentSelection = null;
        private MatchingTile currentSelection2 = null;
        private bool paused = false;

        private void OnEnable()
        {
            StartGame();
        }

        public void StartGame()
        {
            ResetGame();
            SetupTiles();
           
            paused = false;
            puzzleStartedEvent.Invoke();
        }

        public void StopGame()
        {
            paused = true;

            ResetGame();
            puzzleEndedEvent.Invoke();
        }

        private void ResetGame()
        {
            currentSelection = null;
            currentSelection2 = null;
            correctTiles.Clear();

            foreach (MatchingTile _tile in matchingTiles)
            {
                _tile.ClearTile();
                _tile.FlipDown();
            }
        }

        private void SetupTiles()
        {
            List<Tile> _tiles = new List<Tile>(tiles);
            List<MatchingTile> _matchingTiles = new List<MatchingTile>(matchingTiles);

            while (_tiles.Count > 0)
            {
                int _index = Random.Range(0, _tiles.Count);
                Tile _tile = _tiles[_index];
                _tiles.Remove(_tile);

                if (_matchingTiles.Count > 0)
                {
                    int _index2 = Random.Range(0, _matchingTiles.Count);
                    MatchingTile _matchingtile1 = _matchingTiles[_index2];
                    _matchingtile1.SetTile(_tile, this);
                    _matchingTiles.Remove(_matchingtile1);
                }

                if (_matchingTiles.Count > 0)
                {
                    int _index3 = Random.Range(0, _matchingTiles.Count);
                    MatchingTile _matchingtile2 = _matchingTiles[_index3];
                    _matchingtile2.SetTile(_tile, this);
                    _matchingTiles.Remove(_matchingtile2);
                }
            }
        }

        public void Click(MatchingTile tile) 
        {
            if(paused)
            {
                return;
            }

            if(tile == null)
            {
                return;
            }

            if (currentSelection == null)
            {
                currentSelection = tile;
            }
            else
            {
                currentSelection2 = tile;
                paused = true;

                if(currentSelection.tile == currentSelection2.tile)
                {
                    StartCoroutine(SucessCoroutine());
                }
                else
                {
                    StartCoroutine(RetryCoroutine());
                }
            }

            tile.FlipUp();
        }

        private IEnumerator SucessCoroutine()
        {
            yield return new WaitForSeconds(resetDelay);

            if (currentSelection != null)
            {
                currentSelection.FlipUp();
            }

            if (currentSelection2 != null)
            {
                currentSelection2.FlipUp();
            }

            correctTiles.Add(currentSelection);
            correctTiles.Add(currentSelection2);

            if(correctTiles.Count >= matchingTiles.Count)
            {
                puzzleSuccessEvent.Invoke();
                StopGame();
            }

            currentSelection = null;
            currentSelection2 = null;
            paused = false;
        }

        private IEnumerator RetryCoroutine()
        {
            yield return new WaitForSeconds(resetDelay);
            
            if(currentSelection != null)
            {
                currentSelection.FlipDown();
            }

            if(currentSelection2 != null) 
            {
                currentSelection2.FlipDown();
            }

            currentSelection = null;
            currentSelection2 = null;
            paused = false;
        }
    }
}
