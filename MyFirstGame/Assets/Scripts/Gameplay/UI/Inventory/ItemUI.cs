using UnityEngine;
using UnityEngine.UI;
using Service.Framework.Inventory;
using TMPro;

namespace Gameplay.UI.Inventory
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private Button itemButton;

        [SerializeField]
        private TextMeshProUGUI itemCount;
        
        [SerializeField]
        private TextMeshProUGUI itemName;

        private void OnEnable()
        {
            if (icon != null)
            {
                icon.sprite = null;
                icon.enabled = false;
            }

            if(itemName != null)
            {
                itemName.text = "";
            }

            if (itemButton == null)
            {
                itemButton = GetComponent<Button>();
                if (itemButton != null)
                {
                    itemButton.onClick.AddListener(OnClick);
                }
            }
        }

        public void SetItem(Item item, int amount)
        {
            if (item == null)
            {
                return;
            }

            if (itemName != null)
            {
                itemName.text = item.ItemName;
            }

            if (icon != null)
            {
                icon.enabled = true;
                icon.sprite = item.Icon;
            }

            if (itemCount != null)
            {
                itemCount.text = amount.ToString();
            }
        }

        public void Clear()
        {
            if (itemName != null)
            {
                itemName.text = "";
            }

            if (icon != null)
            {
                icon.sprite = null;
                icon.enabled = false;
            }

            if (itemCount != null)
            {
                itemCount.text = "";
            }
        }

        public void OnClick()
        {
            //TODO: notify selection system that this item is selected
        }
    }
}
