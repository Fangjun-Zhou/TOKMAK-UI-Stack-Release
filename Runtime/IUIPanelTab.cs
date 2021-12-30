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
        public void SwitchPanel(IUIPanelElement panel);
    }
}