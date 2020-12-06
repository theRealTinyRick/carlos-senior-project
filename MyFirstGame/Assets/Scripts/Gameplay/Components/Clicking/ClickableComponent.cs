using UnityEngine;
using Service.Core.Extensions;

namespace Gameplay.Components
{
    [System.Serializable]
    public class ClickEvent : UnityEngine.Events.UnityEvent { }

    [RequireComponent(typeof(Collider))]
    public class ClickableComponent : MonoBehaviour
    {
        [SerializeField]
        public ClickEvent clickedEvent = new ClickEvent();

        public void Click()
        {
            clickedEvent?.Invoke();
        }

        private void Awake()
        {
            if(GetComponent<Collider>() == null)
            {
                Debug.LogError("[ClickableComponent]: this component will not work unless there is a collider on the gameobject.");
            }

            // check if we are in the layer mask and show an error. 
            if(!gameObject.WithinLayerMask(ClickingComponent.InteractableLayerMask))
            {
                Debug.LogError("[ClickableComponent]: this component will not work unless it is within the layermask of the clicking component.");
            }
        }
    }
}