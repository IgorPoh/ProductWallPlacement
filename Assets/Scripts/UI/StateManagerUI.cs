using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WallFitter
{
    

    public enum StateUI
    {
        Selection,
        Reselection,
        Fitting,
        Reset
    }
    public class StateManagerUI : MonoBehaviour
    {
        [SerializeField]
        Button SetButton;

        [SerializeField]
        GameObject SetPanel;

        [SerializeField]
        GameObject FitPanel;


        public event EventHandler<EventArgs<int>> OnStateChanged;

        StateUI _currentState = StateUI.Selection;

        private void Start()
        {
            ChangeState(StateUI.Selection);
        }

        public StateUI currentState
        {
            get
            {
                return this._currentState;
            }
            set
            {
                this._currentState = value;
            }
        }
        public void ChangeState(StateUI state)
        {
            currentState = state;
            StartCoroutine(state.ToString() + "State");
            if (OnStateChanged != null)
            {
                OnStateChanged.Invoke(this, new EventArgs<int>((int)state));
            }
        }


        //UI States
        IEnumerator SelectionState()
        {
            yield return new WaitForEndOfFrame();
            SetPanel.SetActive(true);
            FitPanel.SetActive(false);
            SetButton.interactable = false;
            while (currentState == StateUI.Selection) yield return null;
            SetPanel.SetActive(false);
        }

        IEnumerator ReselectionState()
        {
            yield return new WaitForEndOfFrame();
            SetPanel.SetActive(true);
            FitPanel.SetActive(false);
            SetButton.interactable = true;
            while (currentState == StateUI.Reselection) yield return null;
            SetPanel.SetActive(false);
            SetButton.interactable = false;
        }

        IEnumerator FittingState()
        {
            yield return new WaitForEndOfFrame();
            FitPanel.SetActive(true);

            while (currentState == StateUI.Fitting) yield return null;

            FitPanel.SetActive(false);
        }
        
        IEnumerator ResetState()
        {
            yield return new WaitForEndOfFrame();
            //Now we do not have code here
            while (currentState == StateUI.Reset) yield return null;

        }

        

    }
}