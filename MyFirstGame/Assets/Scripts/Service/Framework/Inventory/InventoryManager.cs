using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Service.Framework.Inventory
{
    [System.Serializable]
    public class Slot
    {
        [SerializeField]
        public Item item;
        
        [SerializeField]
        public int amount = 1;
    }

    [System.Serializable]
    public class InventoryEvent : UnityEvent<Item, int> { }
    
    public class InventoryManager : MonoBehaviour
    {
        private static InventoryManager instance;
        public static InventoryManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<InventoryManager>();
                }

                if(instance == null)
                {
                    Debug.LogError("[InventoryManager]: There needs to be an inventory manager present in the scene.");
                }


                return instance;
            }
        }

        [SerializeField]
        private List<Slot> defaultInvetory = new List<Slot>();

        private Dictionary<Item, int> items = new Dictionary<Item, int>();
        public Dictionary<Item, int> Items
        {
            get
            {
                return items;
            }
            private set
            {
                items = value;
            }
        }

        [SerializeField]
        public InventoryEvent itemAddedEvent = new InventoryEvent();
        
        [SerializeField]
        public InventoryEvent itemRemovedEvent = new InventoryEvent();

        private void Awake()
        {
            instance = this;
            foreach (Slot _slot in defaultInvetory)
            {
                Items.Add(_slot.item, _slot.amount);
                itemAddedEvent.Invoke(_slot.item, _slot.amount);
            }

        }

        public void AddItem(Item item, int amount = 1)
        {
            if(item == null)
            {
                return;
            }

            if(items.ContainsKey(item))
            {
                items[item] += amount;
            }
            else
            {
                items.Add(item, amount);
            }

            itemAddedEvent.Invoke(item, amount);
        }

        public void RemoveItem(Item item, int amount = 1)
        {
            if (item == null)
            {
                return;
            }

            if (items.ContainsKey(item))
            {
                int _amount = amount;

                if(items[item] < _amount)
                {
                    _amount = items[item];
                }
                
                items[item] -= _amount;

                itemRemovedEvent.Invoke(item, _amount);
            }
        }

        public bool HasItem(Item item)
        {
            if(item != null)
            {
                return Items.ContainsKey(item) && Items[item] > 0;
            }

            return false;
        }
    }
}

