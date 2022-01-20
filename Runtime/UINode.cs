using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UINode<T>
    {

        #region Private Field

        private UINode<T> _next;

        private UINode<T> _prev;

        private T _value;
        
        #endregion

        #region Public Field

        public UINode<T> next
        {
            get => _next;
            set => _next = value;
        }
        
        public UINode<T> prev
        {
            get => _prev;
            set => _prev = value;
        }

        public T value
        {
            get => _value;
            set => _value = value;
        }

        #endregion
    }
}

