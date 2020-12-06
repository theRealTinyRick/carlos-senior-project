using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service.Core.Extensions
{
    public static class GameobjectExtensions
    {
        public static bool WithinLayerMask(this GameObject gameObject, LayerMask layerMask)
        {
            return ((layerMask & (1 << gameObject.layer)) != 0);
        }
    }
}
