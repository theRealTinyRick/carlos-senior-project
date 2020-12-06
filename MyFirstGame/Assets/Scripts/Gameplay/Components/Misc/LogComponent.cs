using UnityEngine;

namespace Gameplay.Components.Misc
{
    public class LogComponent : MonoBehaviour
    {
        public void Log(string message)
        {
            Debug.Log(string.Format("[LogComponent on {0}]:: {1}", gameObject.name, message));
        }

        public void Warning(string message)
        {
            Debug.LogWarning(string.Format("[LogComponent on {0}]:: {1}", gameObject.name, message));
        }

        public void Error(string message)
        {
            Debug.LogError(string.Format("[LogComponent on {0}]:: {1}", gameObject.name, message));
        }
    }
}