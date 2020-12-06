using UnityEngine;
using UnityEngine.UI;

namespace Service.Framework.Inventory
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Game/Create New Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private string itemName;
        public string ItemName
        {
            get
            {
                return itemName;
            }
        }

        [SerializeField]
        private Sprite icon;
        public Sprite Icon
        {
            get
            {
                return icon;
            }
        }
    }
}

