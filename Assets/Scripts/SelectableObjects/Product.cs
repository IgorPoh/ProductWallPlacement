using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    public class Product : SelectableObject
    {
        private ProductPrefs currentModel;


        private void Awake()
        {
            currentModel = model as ProductPrefs;
            currentModel.DefaultPosition = transform.position;
        }


        public void MoveToWall(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        protected override void SetDefaultState()
        {
            base.SetDefaultState();
            MoveToWall(currentModel.DefaultPosition);
        }
    }
}