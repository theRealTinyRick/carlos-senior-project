using UnityEngine;

namespace Service.Core.Framework
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField]
        public InventoryEvent itemAddedEvent = new InventoryEvent();

        [SerializeField]
        public InventoryEvent itemRemovedEvent = new InventoryEvent();

        private InventoryManager inventoryManager;

        private void OnEnable()
        {
            inventoryManager = InventoryManager.Instance;       
            if(inventoryManager != null)
            {
                inventoryManager.itemAddedEvent.AddListener(itemAddedEvent.Invoke);
                inventoryManager.itemRemovedEvent.AddListener(itemRemovedEvent.Invoke);
            }
        }

        private void OnDisable()
        {
            if (inventoryManager != null)
            {
                inventoryManager.itemAddedEvent.RemoveListener(itemAddedEvent.Invoke);
                inventoryManager.itemRemovedEvent.RemoveListener(itemRemovedEvent.Invoke);
            }
        }

        public void AddItem(Item item, int amount)
        {
            if (inventoryManager != null)
            {
                inventoryManager.AddItem(item, amount);
            }
        }

        public void RemoveItem(Item item, int amount)
        {
            if (inventoryManager != null)
            {
                inventoryManager.RemoveItem(item, amount);
            }
        }
    }
}

