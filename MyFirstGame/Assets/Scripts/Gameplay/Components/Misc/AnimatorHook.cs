using UnityEngine;

namespace Gameplay.Components.Misc
{
    public class AnimatorHook : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private void OnEnable()
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
                if(animator == null)
                {
                    Debug.LogError("No Animator");
                }
            }
        }

        public void SetBool(string name, bool value)
        {
            if(animator != null)
            {
                animator.SetBool(name, value);
            }
            else
            {
                Debug.LogError("No Animator");
            }
        }

        public void SetTrigger(string name)
        {
            if (animator != null)
            {
                animator.SetTrigger(name);
            }
            else
            {
                Debug.LogError("No Animator");
            }
        }

        public void SetFloat(string name, float value)
        {
            if (animator != null)
            {
                animator.SetFloat(name, value);
            }
            else
            {
                Debug.LogError("No Animator");
            }
        }

        public void Play(string name)
        {
            if (animator != null)
            {
                animator.Play(name);
            }
            else
            {
                Debug.LogError("No Animator");
            }
        }
    }
}

