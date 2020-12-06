using UnityEngine;

namespace Service.Framework.Inventory.Components
{
    [System.Serializable]
    public class PickupEventType : UnityEngine.Events.UnityEvent<Item, int> { }

    public class PickupComponent : MonoBehaviour
    {
        [SerializeField]
        private Item itemToAdd;

        [SerializeField]
        private int numberToAdd = 1;

        [SerializeField]
        public PickupEventType pickedUpEvent = new PickupEventType();

        public void Pickup()
        {
            if(itemToAdd != null)
            {
                InventoryManager.Instance.AddItem(itemToAdd, numberToAdd);
                pickedUpEvent.Invoke(itemToAdd, numberToAdd);
            }
            else
            {
                Debug.LogError(string.Format("[PickupComponent on {0}]:: No item to add.", gameObject.name));
            }
        }
    }
}
