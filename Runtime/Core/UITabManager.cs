using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UITabManager : UIManager, IUIPanelTab
    {
        #region Private Field

        private List<IUIPanelElement> _panelElements = new List<IUIPanelElement>();

        private IUIPanelElement _currPanel;

        #endregion

        private void Awake()
        {
            foreach (UIPanelElement panelElement in UIPanels)
            {
                _panelElements.Add(panelElement);
                panelElement.OnInitialization();
            }

            if (useInitializePanel)
            {
                initializationPanel.OnInactive2Active();
                _currPanel = initializationPanel;
            }
        }

        #region IUITabManager Callback
        
        public void SwitchPanel(IUIPanelElement panel)
        {
            if (_currPanel == panel)
            {
                Debug.Log("Panel already open.");
                return;
            }
            
            _currPanel.OnActive2Inactive();
            panel.OnInactive2Active();

            _currPanel = panel;
        }

        public async Task SwitchPanelAsync(IUIPanelElement panel)
        {
            if (_currPanel == panel)
            {
                Debug.Log("Panel already open.");
                return;
            }
            
            await _currPanel.OnActive2InactiveAsync();
            panel.OnInactive2Active();

            _currPanel = panel;
        }

        #endregion
    }
}