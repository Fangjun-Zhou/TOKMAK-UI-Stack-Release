using System;
using System.Threading.Tasks;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    [RequireComponent(typeof(UIEventInvoker))]
    public class DelayUIEventInvoker : MonoBehaviour
    {
        #region Private Field

        /// <summary>
        /// The UI Event invoker use to invoke the event.
        /// </summary>
        private UIEventInvoker _invoker;

        #endregion

        #region Public Field

        /// <summary>
        /// The time to delay.
        /// </summary>
        public float delayTime;

        #endregion

        private void Awake()
        {
            _invoker = gameObject.GetComponent<UIEventInvoker>();
        }

        #region Public Methods

        public async void DelayActive2Background()
        {
            await Task.Delay((int)(delayTime * 1000));
            _invoker.FinishActive2Background();
        }
        
        public async void DelayActive2Inactive()
        {
            await Task.Delay((int)(delayTime * 1000));
            _invoker.FinishActive2Inactive();
        }
        
        public async void DelayBackground2Inactive()
        {
            await Task.Delay((int)(delayTime * 1000));
            _invoker.FinishBackground2Inactive();
        }

        #endregion
    }
}