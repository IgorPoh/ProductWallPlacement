using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    public class SelectionManager : MonoBehaviour
    {
        


        private Wall wall;
        private Product product;

        [SerializeField]
        SelectionController SelectionController;

        [SerializeField]
        StateManagerUI StateManagerUI;

        [SerializeField]
        ResetController ResetController;

        private void OnValidate()
        {
            if (SelectionController == null)
                SelectionController = FindObjectOfType<SelectionController>();

            if (ResetController == null)
                ResetController = FindObjectOfType<ResetController>();

            if (StateManagerUI == null)
                StateManagerUI = FindObjectOfType<StateManagerUI>();
        }

        // Start is called before the first frame update
        void Start()
        {
            SelectionState();

            ResetController.OnReset += SelectionState;
        }

        void OnSelectObject(object sender, SelectableObject obj)
        {
            ChangeSelection<Wall>(obj, ref wall);
            ChangeSelection<Product>(obj, ref product);
            if (wall != null && product != null)
                StateManagerUI.ChangeState(StateUI.Reselection);

        }

        void ChangeSelection<T>(SelectableObject inputObject, ref T selectedObject) where T : SelectableObject
        {
            var input = inputObject as T;
            if ( input != null)
            {
                if (selectedObject != null)
                    selectedObject.IsSelected = false;
                selectedObject = input;
                selectedObject.IsSelected = true;

            }

                
        }

        //State when we can select objects
        public void SelectionState()
        {
            SelectionController.OnSelect += OnSelectObject;
        }

        public void PlaceOnWall()
        {
            StateManagerUI.ChangeState(StateUI.Fitting);
            product.MoveToWall(wall.GetCentralPoint());
            UnselectionState();
        }

        //State when we can not select objects(fitting and reset states)
        public void UnselectionState()
        {
            SelectionController.OnSelect -= OnSelectObject;
            
        }


    }
}