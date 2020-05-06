using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WallFitter
{
    public class ResetController : MonoBehaviour
    {
        private StateManagerUI StateManagerUI;

        public event Action OnReset;

        private void OnValidate()
        {

            if (StateManagerUI == null)
                StateManagerUI = FindObjectOfType<StateManagerUI>();
        }

        public void Reset()
        {
            //code for resetting all states and objects in the app. Now just firing event

            StateManagerUI.ChangeState(StateUI.Reset);
            StateManagerUI.ChangeState(StateUI.Selection);
            OnReset.Invoke();
            
        }
    }
}