using UnityEngine;

namespace Gameplay.Components.Misc
{
    [System.Serializable]
    public class LifetimeEventType : UnityEngine.Events.UnityEvent { }

    public class LifetimeEvents : MonoBehaviour
    {
        [SerializeField]
        public LifetimeEventType startEvent = new LifetimeEventType();
        
        [SerializeField]
        public LifetimeEventType awakeEvent = new LifetimeEventType();
        
        [SerializeField]
        public LifetimeEventType enabledEvent = new LifetimeEventType();
        
        [SerializeField]
        public LifetimeEventType disabledEvent = new LifetimeEventType();

        private void Start()
        {
            startEvent.Invoke();
        }

        private void Awake()
        {
            awakeEvent.Invoke();
        }

        private void OnEnable()
        {
            enabledEvent.Invoke();
        }

        private void OnDisable()
        {
            disabledEvent.Invoke();
        }
    }
}
