using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UINode : IUINode
    {

        #region Private Field
        /// <summary>
        /// value stored in current node
        /// </summary>
        UIPanelElement value = null;

        /// <summary>
        /// linked next node
        /// </summary>
        UINode next = null;

        /// <summary>
        /// linked previous node
        /// </summary>
        UINode prev = null;
        #endregion


        /// <summary>
        /// Get the next node
        /// </summary>
        /// <returns></returns>
        public IUINode GetNext()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get the previous node
        /// </summary>
        /// <returns></returns>
        public IUINode GetPrev()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Set current node's value
        /// </summary>
        /// <param name="value"></param>
        public void SetVal(UIPanelElement value)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get current node's value
        /// </summary>
        /// <returns></returns>
        public UIPanelElement GetVal()
        {
            throw new System.NotImplementedException();
        }

    }
}

