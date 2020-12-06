using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI.GameMenu
{
    public class GameMenuComponent : MonoBehaviour
    {
        [SerializeField]
        private KeyCode menuKey = KeyCode.Space;

        [SerializeField]
        private GameObject menuPrefab;

        private GameMenuUI spawnedMenu;

        private void Awake()
        {
            if(menuPrefab != null)
            {
                spawnedMenu = Instantiate(menuPrefab).GetComponent<GameMenuUI>();
                spawnedMenu.CloseMenu();
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(menuKey))
            {
                if(spawnedMenu != null)
                {
                    spawnedMenu.ToggleMenu();
                }
            }
        }
    }
}