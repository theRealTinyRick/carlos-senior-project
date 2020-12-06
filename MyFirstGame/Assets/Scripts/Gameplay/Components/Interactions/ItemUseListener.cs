using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Service.Framework.Inventory;

namespace Gameplay.Components.Interactions
{
    public class ItemUseListener : MonoBehaviour
    {
        [SerializeField]
        public UseItemEvent itemUsedInstancedEvent = new UseItemEvent();

        [SerializeField]
        private Item item;

        private void Awake()
        {
            UseItemComponent.itemUsedEvent.AddListener(OnItemUsed);
        }

        private void OnItemUsed(Item item)
        {
            if(this.item == item)
            {
                itemUsedInstancedEvent.Invoke(item);
            }
            else
            {
                Debug.Log("Wrong item.");
            }
        }
    }
}