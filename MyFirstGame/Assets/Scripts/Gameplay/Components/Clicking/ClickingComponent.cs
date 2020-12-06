using UnityEngine;

namespace Gameplay.Components
{
    public class ClickingComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask interactableLayerMask;
        public static LayerMask InteractableLayerMask
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<ClickingComponent>();
                }

                if(instance != null)
                {
                    return instance.interactableLayerMask;
                }
                return -1;
            }
        }

        private static ClickingComponent instance = null;
        private bool isLocked = false;

        public void Lock()
        {
            SetLock(locked: true);
        }

        public void Unlock()
        {
            SetLock(locked: false);
        }

        public void SetLock(bool locked)
        {
            isLocked = locked;
        }

        private void Update()
        {
            if(isLocked)
            {
                return;
            }

            if(Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }

        private void OnClick()
        {
            // do raycast
            RaycastHit _raycastHit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(_ray, out _raycastHit, 1000, interactableLayerMask))
            {
                ClickableComponent _clickableComponent = _raycastHit.collider.gameObject.GetComponent<ClickableComponent>();
                if(_clickableComponent != null)
                {
                    _clickableComponent.Click();
                }
            }
        }
    }
}
