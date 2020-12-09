using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI.GameMenu
{
    public class GameMenuComponent : MonoBehaviour
    {
        [SerializeField]
        private KeyCode menuKey = KeyCode.Space;

        private void Update()
        {
            if(Input.GetKeyDown(menuKey))
            {
                if(GameMenuUI.Instance != null)
                {
                    GameMenuUI.Instance.ToggleMenu();
                }
                else
                {
                    Debug.LogError("No game menu was found. Please ensure one is in the scene.");
                }
            }
        }
    }
}