using System;
using System.Threading.Tasks;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UITabManager : UIManager, IUIPanelTab
    {
        #region Private Field

        // TODO: Use some private data structure to manage the panel tabs.

        #endregion
        
        #region IUITabManager Callback
        
        public void SwitchPanel(IUIPanelElement panel)
        {
            throw new NotImplementedException();
        }

        public async Task SwitchPanelAsync(IUIPanelElement panel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}