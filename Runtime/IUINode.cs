using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public interface IUINode
    {
        /// <summary>
        /// The next node.
        /// </summary>
        IUINode next { get; set; }
        
        /// <summary>
        /// The previous node.
        /// </summary>
        IUINode prev { get; set; }

        /// <summary>
        /// The value of the node.
        /// </summary>
        UIPanelElement value { get; set; }
    }
}


