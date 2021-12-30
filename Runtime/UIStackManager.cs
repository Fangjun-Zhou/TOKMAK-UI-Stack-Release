using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The SerializableDictionary that has int value as keys and UIPanelElements as values
    /// </summary>
    [System.Serializable]
    public class UIPanelElementStringDict : SerializableDictionary<UIPanelElement, string>{}
    
    /// <summary>
    /// This is the Stack Manager for the UI Stack System
    /// This MonoBehaviour should be attached to every root GameObject of UIPanelElements
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Stack Manager")]
    public class UIStackManager : MonoBehaviour, IUIPanelStack
    {
        #region Public Field
        
        /// <summary>
        /// All the available UIPanelElements
        /// </summary>
        [Tooltip("This field list all the UIPanelElement children. " +
                 "The key is panel name and value is UIPanelElement MonoBehaviour.")]
        public UIPanelElementStringDict UIPanels;

        /// <summary>
        /// if the UIStackManager has an initialization panel
        /// </summary>
        public bool useInitializePanel = false;

        /// <summary>
        /// The panel that will be pushed into the stack when Start
        /// </summary>
        public UIPanelElement initializationPanel;
        
        #endregion

        #region Private Field

        /// <summary>
        /// The internal UI Stack
        /// </summary>
        private Stack<UIPanelElement> _UIStack = new Stack<UIPanelElement>();

        #endregion

        private void Start()
        {
            
        }

        #region UIStack Operation

        public void OpenPanel(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public async void OpenPanelAsync(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public void ClosePanel(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public async void ClosePanelAsync(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}