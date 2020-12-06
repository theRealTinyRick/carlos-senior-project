using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Gameplay.UI.Puzzles
{
    public class MatchingTile : MonoBehaviour
    {
        [SerializeField]
        private Image backface;
    
        [SerializeField]
        private Image frontface;

        [SerializeField]
        private Button button;

        [SerializeField]
        private MatchingPuzzle puzzle;
        
        public Tile tile;

        public void SetTile( Tile tile, MatchingPuzzle puzzle )
        {
            if (puzzle == null)
            {
                return;
            }

            if(tile == null)
            {
                return;
            }

            this.puzzle = puzzle;
            this.tile = tile;

            if(frontface != null)
            {
                if (tile.Icon != null)
                {
                    frontface.sprite = tile.Icon;
                }
                else
                {
                    frontface.color = tile.IconColor;
                }
            }

            if(button != null)
            {
                button.onClick.AddListener(() => puzzle.Click(this));
            }
            else
            {
                Debug.LogError("Button is missing");
            }
        }

        public void ClearTile()
        {
            puzzle = null;
            tile = null;

            if (frontface != null)
            {
                frontface.sprite = null;
            }

            if (button != null)
            {
                button.onClick.RemoveAllListeners();
            }
        }

        public void FlipUp()
        {
            if(backface != null)
            {
                backface.gameObject.SetActive(false);
            }

            if (frontface != null)
            {
                frontface.gameObject.SetActive(true);
            }
        }

        public void FlipDown()
        {
            if (backface != null)
            {
                backface.gameObject.SetActive(true);
            }

            if (frontface != null)
            {
                frontface.gameObject.SetActive(false);
            }
        }
    }
}

