using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace PanelOpener
{
    public class TabPanelOpener : UIPanelChild
    {
        #region Public Field

        [ValidateInput("IsPanelValid")]
        public UIPanelElement targetPanel;

        #endregion

        #region Public Method

        public void OpenPanelAsync()
        {
            ((UITabManager) rootPanel.panelRootManager).SwitchPanelAsync(targetPanel);
        }
        
        public void OpenPanel()
        {
            ((UITabManager) rootPanel.panelRootManager).SwitchPanel(targetPanel);
        }

        #endregion
    }
}