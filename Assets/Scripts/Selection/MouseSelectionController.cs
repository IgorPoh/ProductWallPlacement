using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    public class MouseSelectionController : SelectionController
    {
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Select(Input.mousePosition);
            }
        }


    }
}