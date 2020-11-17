using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service.Core.Framework
{
    public class Item : ScriptableObject
    {
        [SerializeField]
        private string itemName;
        public string ItemName
        {
            get
            {
                return itemName;
            }
        }

    }
}

