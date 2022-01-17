using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public interface IUINode
    {
        /// <summary>
        /// Get the next node
        /// </summary>
        /// <returns></returns>
        IUINode GetNext();

        /// <summary>
        /// Get the previous node
        /// </summary>
        /// <returns></returns>
        IUINode GetPrev();

        /// <summary>
        /// Set current node's value
        /// </summary>
        /// <param name="value"></param>
        void SetVal(UIPanelElement value);

        /// <summary>
        /// Get current node's value
        /// </summary>
        /// <returns></returns>
        UIPanelElement GetVal();
    }
}


