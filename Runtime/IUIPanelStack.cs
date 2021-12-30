using System.Threading.Tasks;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The UI Stack interface.
    /// </summary>
    public interface IUIPanelStack
    {
        /// <summary>
        /// The method to open a panel.
        /// </summary>
        /// <param name="panelElement">the panel to open.</param>
        void OpenPanel(IUIPanelElement panelElement);

        /// <summary>
        /// The async method to open a panel.
        /// </summary>
        /// <param name="panelElement">the panel to open.</param>
        /// <returns>async Task</returns>
        Task OpenPanelAsync(IUIPanelElement panelElement);

        /// <summary>
        /// The method to close a panel.
        /// </summary>
        /// <param name="panelElement">the panel to close.</param>
        void ClosePanel(IUIPanelElement panelElement);

        /// <summary>
        /// The async method to close a panel.
        /// </summary>
        /// <param name="panelElement">the panel to close.</param>
        /// <returns>async Task</returns>
        Task ClosePanelAsync(IUIPanelElement panelElement);
    }
}