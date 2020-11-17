using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Service.Core.Framework
{
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
                return instance;
            }
        }

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
    }
}

