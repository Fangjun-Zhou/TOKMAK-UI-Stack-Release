using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace PanelOpener
{
    public class StackPanelCloser : UIPanelChild
    {
        #region Public Field

        public bool closeSelf;

        [HideIf("closeSelf")]
        [ValidateInput("IsPanelValid")]
        public UIPanelElement targetPanel;

        #endregion

        #region Public Methods

        public void ClosePanelAsync()
        {
            if (closeSelf)
                ((UIStackManager) rootPanel.panelRootManager).ClosePanelAsync(rootPanel);
            else
                ((UIStackManager) rootPanel.panelRootManager).ClosePanelAsync(targetPanel);
        }
        
        public void ClosePanel()
        {
            if (closeSelf)
                ((UIStackManager) rootPanel.panelRootManager).ClosePanel(rootPanel);
            else
                ((UIStackManager) rootPanel.panelRootManager).ClosePanel(targetPanel);
        }

        #endregion
    }
}