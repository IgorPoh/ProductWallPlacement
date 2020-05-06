using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallFitter
{
    //Bace class for objects which could be selected. In this project - walls and products
    public abstract class SelectableObject : MonoBehaviour
    {
        [SerializeField]
        protected SelectablePrefs model;

        [SerializeField]
        private ResetController ResetController;


        private bool isSelected;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                float size;
                if (value) size = model.OutlineSizeSelected;
                else size = model.OutlineSizeUnselected;
                gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_OutlineExtrusion", size);
            }
        }


        private void OnValidate()
        {

            if (ResetController == null)
                ResetController = GameObject.FindObjectOfType<ResetController>();
        }
        protected void Start()
        {

            SetDefaultState();

            ResetController.OnReset += SetDefaultState;
        }

       
        protected virtual void SetDefaultState()
        {

            IsSelected = false;
        }

    }
}