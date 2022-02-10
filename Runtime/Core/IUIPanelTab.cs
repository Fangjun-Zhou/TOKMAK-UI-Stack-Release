using System.Threading.Tasks;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The UI Tab interface.
    /// </summary>
    public interface IUIPanelTab
    {
        /// <summary>
        /// The method to switch the panel.
        /// </summary>
        /// <param name="panel">the panel to switch.</param>
        void SwitchPanel(IUIPanelElement panel);

        /// <summary>
        /// The async method to switch a panel.
        /// </summary>
        /// <param name="panel">the panel to switch.</param>
        /// <returns>async Task</returns>
        Task SwitchPanelAsync(IUIPanelElement panel);
    }
}