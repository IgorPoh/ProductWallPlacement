using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    public abstract class SelectionController : MonoBehaviour
    {
        Camera mainCamera;

        public event EventHandler<SelectableObject> OnSelect;
        

        private void Start()
        {
            mainCamera = Camera.main;
        }

        protected void Select(Vector3 selectionPosition)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(selectionPosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (OnSelect != null && hit.collider.gameObject.TryGetComponent<SelectableObject>(out var SelectedObject))
                    OnSelect.Invoke(this, SelectedObject);
            }
                
        }

    }
}