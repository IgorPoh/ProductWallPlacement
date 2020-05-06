using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    [CreateAssetMenu]
    public class ProductPrefs : SelectablePrefs
    {
        public Vector3 DefaultPosition { get; set; }

    }
}