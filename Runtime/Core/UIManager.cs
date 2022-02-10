using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{

    /// <summary>
    /// The base class for all the UIManagers, including StackManager and TabManager.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// All the available UIPanelElements
        /// </summary>
        [Tooltip("This field list all the UIPanelElement children. " +
                 "The key is panel name and value is UIPanelElement MonoBehaviour.")]
        public List<UIPanelElement> UIPanels;

        /// <summary>
        /// if the UIStackManager has an initialization panel
        /// </summary>
        public bool useInitializePanel = false;

        /// <summary>
        /// The panel that will be pushed into the stack when Start
        /// </summary>
        public UIPanelElement initializationPanel;
    }
}