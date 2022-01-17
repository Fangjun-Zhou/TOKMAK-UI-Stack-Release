using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UINode : IUINode
    {

        #region Private Field

        private IUINode _next;

        private IUINode _prev;

        private UIPanelElement _value;
        
        #endregion

        #region Public Field

        public IUINode next
        {
            get => _next;
            set => _next = value;
        }
        
        public IUINode prev
        {
            get => _prev;
            set => prev = value;
        }

        public UIPanelElement value
        {
            get => _value;
            set => _value = value;
        }

        #endregion
    }
}

