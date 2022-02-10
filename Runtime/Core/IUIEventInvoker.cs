using System;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// The universal interface for UI lifecycle event invoking.
    /// </summary>
    public interface IUIEventInvoker
    {
        /// <summary>
        /// The action triggered when the panel(UI object) finish change from active to background.
        /// </summary>
        Action finishActive2Background { get; set; }
        
        /// <summary>
        /// The action triggered when the panel(UI object) finish change from active to inactive.
        /// </summary>
        Action finishActive2Inactive { get; set; }
        
        /// <summary>
        /// The action triggered when the panel(UI object) finish change from background to inactive.
        /// </summary>
        Action finishBackground2Inactive { get; set; }

        /// <summary>
        /// The method called to force trigger finishActive2Background event.
        /// Always used by UI object animation event.
        /// </summary>
        void FinishActive2Background();

        /// <summary>
        /// The method called to force trigger finishActive2Inactive event.
        /// Always used by UI object animation event.
        /// </summary>
        void FinishActive2Inactive();

        /// <summary>
        /// The method called to force trigger finishBackground2Inactive event.
        /// Always used by UI object animation event.
        /// </summary>
        void FinishBackground2Inactive();
    }
}