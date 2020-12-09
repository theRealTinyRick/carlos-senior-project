using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Puzzles
{
    public class FindTheObjectComponent : MonoBehaviour
    {
        [SerializeField]
        private FindTheObjectID objectID;
        public FindTheObjectID ObjectID
        {
            get
            {
                return objectID;
            }
        }

        [SerializeField]
        private Button button;

        [SerializeField]
        private bool found = false;

        [SerializeField]
        public FindTheObjectEventNoParam objectWasFoundEvent = new FindTheObjectEventNoParam();
        
        [SerializeField]
        public FindTheObjectEventNoParam resetEvent = new FindTheObjectEventNoParam();
        
        public void Setup(FindTheObjectManager manager)
        {
            if(manager == null)
            {
                return;
            }

            if(button == null)
            {
                button = GetComponent<Button>();
            }

            if(button != null)
            {
                button.onClick.AddListener(() => 
                {
                    if(!found && manager.Playing)
                    {
                        manager.OnClick(this);
                        found = true;
                        objectWasFoundEvent.Invoke();
                    }
                });
            }
            else
            {
                Debug.LogError("Non button found");
            }

            found = false;
        }

        public void ResetObject()
        {
            found = false;
            resetEvent.Invoke();
        }
    }
}
