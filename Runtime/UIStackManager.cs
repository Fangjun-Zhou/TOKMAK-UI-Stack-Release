using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// This is the Stack Manager for the UI Stack System
    /// This MonoBehaviour should be attached to every root GameObject of UIPanelElements
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Stack Manager")]
    public class UIStackManager : UIManager, IUIPanelStack
    {
        #region Public Field
        
        
        
        #endregion

        #region Private Field

        /// <summary>
        /// The internal UI Stack
        /// </summary>
        private Stack<IUIPanelElement> _UIStack = new Stack<IUIPanelElement>();

        #endregion

        private void Start()
        {
            
        }

        #region UIStack Operation

        public void OpenPanel(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public async Task OpenPanelAsync(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public void ClosePanel(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public async Task ClosePanelAsync(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}