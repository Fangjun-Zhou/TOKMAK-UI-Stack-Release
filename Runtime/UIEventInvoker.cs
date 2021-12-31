using System;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UIEventInvoker : MonoBehaviour, IUIEventInvoker
    {
        public Action finishActive2Background { get; set; }
        public Action finishActive2Inactive { get; set; }
        public Action finishBackground2Inactive { get; set; }
        
        public void FinishActive2Background()
        {
            finishActive2Background?.Invoke();
        }

        public void FinishActive2Inactive()
        {
            finishActive2Inactive?.Invoke();
        }

        public void FinishBackground2Inactive()
        {
            finishBackground2Inactive?.Invoke();
        }
    }
}