namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The interface that defines the basic lifecycle of a UIPanelElement.
    /// </summary>
    public interface IUIPanelElement
    {
        /// <summary>
        /// The callback function called when the panel change from Inactive state to Active state.
        /// </summary>
        void OnInactive2Active();

        /// <summary>
        /// The callback function called when the panel change from Inactive state to Background state.
        /// </summary>
        void OnInactive2Background();

        /// <summary>
        /// The callback function called when the panel change from Background state to Active state.
        /// </summary>
        void OnBackground2Active();

        /// <summary>
        /// The callback function called when the panel change from Active state to Background state.
        /// </summary>
        void OnActive2Background();

        /// <summary>
        /// The async callback function called when the panel change from Active state to Background state.
        /// </summary>
        void OnActive2BackgroundAsync();

        /// <summary>
        /// The callback function called when the panel change from Active state to Inactive state.
        /// </summary>
        void OnActive2Inactive();

        /// <summary>
        /// The async callback function called when the panel changed from Active state to Inactive state.
        /// </summary>
        void OnActive2InactiveAsync();

        /// <summary>
        /// The callback function called when the panel changed from the Background state to Inactive state.
        /// </summary>
        void OnBackground2Inactive();

        /// <summary>
        /// The async callback function called when the panel changed from Background state to Inactive state.
        /// </summary>
        void OnBackground2InactiveAsync();
    }
}