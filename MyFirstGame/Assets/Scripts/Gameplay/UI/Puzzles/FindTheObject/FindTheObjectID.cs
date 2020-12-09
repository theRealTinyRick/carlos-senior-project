using UnityEngine;

namespace Gameplay.UI.Puzzles
{
    [CreateAssetMenu(fileName = "New Find The Object", menuName = "Game/Create New Find The Object ID", order = 1)]
    public class FindTheObjectID : ScriptableObject
    {
        [SerializeField]
        private string objectName;
        public string ObjectName
        {
            get
            {
                return objectName;
            }
        }
    }
}
