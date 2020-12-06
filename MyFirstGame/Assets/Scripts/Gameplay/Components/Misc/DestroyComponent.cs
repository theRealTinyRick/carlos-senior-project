using UnityEngine;

namespace Gameplay.Components.Misc
{
    public class DestroyComponent : MonoBehaviour
    {
        [SerializeField]
        private bool destroyOnAwake;
        
        [SerializeField]
        private float delay;

        private float currentTime;
        private bool isRunningClock = false;

        private void Awake()
        {
            if(destroyOnAwake && delay <= 0)
            {
                Destroy();
            }
            else if(destroyOnAwake)
            {
                currentTime = delay;
                isRunningClock = true;
            }
        }

        private void Update()
        {
            if(isRunningClock)
            {
                currentTime -= Time.deltaTime;

                if(currentTime <= 0)
                {
                    Destroy();
                }
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}