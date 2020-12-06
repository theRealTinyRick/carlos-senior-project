using System.Collections.Generic;
using UnityEngine;

using Service.Framework.Inventory;

namespace Gameplay.UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField]
        private List<ItemUI> itemSlots = new List<ItemUI>();

        private InventoryManager inventoryManager;

        private void OnEnable()
        {
            inventoryManager = InventoryManager.Instance;

            if (inventoryManager != null)
            {
                inventoryManager.itemAddedEvent.AddListener(Populate);
                inventoryManager.itemRemovedEvent.AddListener(Populate);

                int _index = 0;
                foreach (KeyValuePair<Item, int> _slot in InventoryManager.Instance.Items)
                {
                    if(itemSlots.Count > _index && _slot.Key != null)
                    {
                        itemSlots[_index].SetItem(_slot.Key, _slot.Value);
                    }
                    _index++;
                }
            }
        }

        private void OnDisable()
        {
            if (inventoryManager != null)
            {
                inventoryManager.itemAddedEvent.RemoveListener(Populate);
                inventoryManager.itemRemovedEvent.RemoveListener(Populate);

                foreach (ItemUI _itemSlot in itemSlots)
                {
                    _itemSlot.Clear();
                }
            }
        }

        private void Populate(Item item, int amount)
        {
            int _index = 0;
            foreach (KeyValuePair<Item, int> _slot in InventoryManager.Instance.Items)
            {
                if (itemSlots.Count > _index && _slot.Key != null)
                {
                    itemSlots[_index].SetItem(_slot.Key, _slot.Value);
                }
                _index++;
            }
        }
    }
}
