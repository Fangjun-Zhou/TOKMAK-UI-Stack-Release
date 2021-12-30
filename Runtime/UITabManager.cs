using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UITabManager : MonoBehaviour, IUIPanelTab
    {
        #region IUITabManager Callback
        
        public void SwitchPanel(IUIPanelElement panel)
        {
            throw new System.NotImplementedException();
        }

        public async void SwitchPanelAsync(IUIPanelElement panel)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}