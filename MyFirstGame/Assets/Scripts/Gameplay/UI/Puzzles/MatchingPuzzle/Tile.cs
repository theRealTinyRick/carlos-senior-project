using UnityEngine;

namespace Gameplay.UI.Puzzles
{
    [CreateAssetMenu(fileName = "New Tile", menuName = "Game/Create New Matching Tile", order = 1)]
    public class Tile : ScriptableObject
    {
        [SerializeField]
        private Sprite icon;
        public Sprite Icon
        {
            get
            {
                return icon;
            }
        }

        [SerializeField]
        private Color iconColor;
        public Color IconColor
        {
            get
            {
                return iconColor;
            }
        }
    }
}

