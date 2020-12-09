using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI.Puzzles
{
    [System.Serializable]
    public class FindTheObjectEvent : UnityEngine.Events.UnityEvent<FindTheObjectID> { }
    
    [System.Serializable]
    public class FindTheObjectEventNoParam : UnityEngine.Events.UnityEvent{ }

    public class FindTheObjectManager : Puzzle
    {
        [SerializeField]
        private List<FindTheObjectID> objectIdsInThisGame = new List<FindTheObjectID>(); 

        [SerializeField]
        public FindTheObjectEvent objectFoundEvent = new FindTheObjectEvent();
        
        [SerializeField]
        public FindTheObjectEventNoParam gameWonEvent = new FindTheObjectEventNoParam();
        
        [SerializeField]
        public FindTheObjectEventNoParam gameStartedEvent = new FindTheObjectEventNoParam();
        
        [SerializeField]
        public FindTheObjectEventNoParam gameFinishedEvent = new FindTheObjectEventNoParam();

        private bool playing = false;
        public bool Playing
        {
            get
            {
                return playing;
            }
        }

        private FindTheObjectComponent[] findTheObjectComponents;
        private List<FindTheObjectID> foundObjects = new List<FindTheObjectID>();

        private void OnEnable()
        {
            StartGame();           
        }

        private void OnDisable()
        {
            StopGame();           
        }

        public void StartGame()
        {
            findTheObjectComponents = GetComponentsInChildren<FindTheObjectComponent>();

            if (findTheObjectComponents != null)
            {
                foreach (FindTheObjectComponent _component in findTheObjectComponents)
                {
                    _component.Setup(this);
                }

                playing = true;
                foundObjects.Clear();
                gameStartedEvent.Invoke();
            }
        }

        public void StopGame()
        {
            playing = true;
            
            if (findTheObjectComponents != null)
            {
                foreach (FindTheObjectComponent _component in findTheObjectComponents)
                {
                    _component.ResetObject();
                }
            }

            foundObjects.Clear();
            gameFinishedEvent.Invoke();
        }

        public void OnClick(FindTheObjectComponent component)
        {
            if(component != null && component.ObjectID != null)
            {
                if(objectIdsInThisGame.Contains(component.ObjectID))
                {
                    foundObjects.Add(component.ObjectID);
                }
            }

            if(foundObjects.Count >= objectIdsInThisGame.Count)
            {
                gameWonEvent.Invoke();
            }
        }
    }
}
