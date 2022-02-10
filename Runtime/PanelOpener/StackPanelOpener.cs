using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace PanelOpener
{
    public class StackPanelOpener : UIPanelChild
    {
        #region Public Field

        [ValidateInput("IsPanelValid")]
        public UIPanelElement targetPanel;

        #endregion

        #region Public Method

        public void OpenPanelAsync()
        {
            ((UIStackManager) rootPanel.panelRootManager).OpenPanelAsync(targetPanel);
        }
        
        public void OpenPanel()
        {
            ((UIStackManager) rootPanel.panelRootManager).OpenPanel(targetPanel);
        }

        #endregion
    }
}