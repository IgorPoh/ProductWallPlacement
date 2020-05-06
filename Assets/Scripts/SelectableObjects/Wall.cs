using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    public class Wall : SelectableObject
    {
        private WallPrefs currentModel;


        private void Awake()
        {
            currentModel = model as WallPrefs;
        }



        public Vector3 GetCentralPoint()
        {
            return currentModel.CentralPoint;
        }
    }
}