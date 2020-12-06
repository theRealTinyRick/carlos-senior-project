using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Service.Framework.Inventory;

namespace Gameplay.Components.Interactions
{
    [System.Serializable]
    public class UseItemEvent : UnityEngine.Events.UnityEvent<Item>{ }

    public class UseItemComponent : MonoBehaviour
    {
        [SerializeField]
        private Item item;

        [SerializeField]
        private bool requireItem = true;

        [SerializeField]
        public UseItemEvent itemUsedInstanceEvent = new UseItemEvent();
        
        public static UseItemEvent itemUsedEvent = new UseItemEvent();

        public void Use()
        {
            if(item != null)
            {
                if (InventoryManager.Instance.HasItem(item) || !requireItem)
                {
                    UseItemComponent.itemUsedEvent.Invoke(item);
                    itemUsedInstanceEvent.Invoke(item);
                    InventoryManager.Instance.RemoveItem(item);
                }
                else
                {
                    Debug.LogError("Cant use no item.");
                }
            }
            else
            {
                Debug.LogError("No item assigned");
            }
        }
    }
}