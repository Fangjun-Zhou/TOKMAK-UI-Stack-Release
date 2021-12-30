using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    /// <summary>
    /// This is the base class for UIPanel
    /// All the UI panel logic class should inherit this class
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Panel Element")]
    public class UIPanelElement : MonoBehaviour, IUIPanelElement
    {
        #region Public Field

        /// <summary>
        /// The root manager of current UIPanelElement
        /// </summary>
        [BoxGroup("Panel Property")]
        public UIManager panelRootManager;

        /// <summary>
        /// The name of current UIPanelElement
        /// </summary>
        [Space]
        [BoxGroup("Panel Property")]
        public string panelName;

        [BoxGroup("UI Stack Event")]
        public UnityEvent inactive2ActiveEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent inactive2BackgroundEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent background2ActiveEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent active2BackgroundEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishActive2BackgroundEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent background2InactiveEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishBackground2InactiveEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent active2InactiveEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishActive2InactiveEvent;
        
        #endregion

        private void Awake()
        {
            
        }
        
        private void OnEnable()
        {
            
        }

        #region IUIPanelElement Callback

        public void OnInactive2Active()
        {
            throw new NotImplementedException();
        }

        public void OnInactive2Background()
        {
            throw new NotImplementedException();
        }

        public void OnBackground2Active()
        {
            throw new NotImplementedException();
        }

        public void OnActive2Background()
        {
            throw new NotImplementedException();
        }

        public async Task OnActive2BackgroundAsync()
        {
            throw new NotImplementedException();
        }

        public void OnActive2Inactive()
        {
            throw new NotImplementedException();
        }

        public async Task OnActive2InactiveAsync()
        {
            throw new NotImplementedException();
        }

        public void OnBackground2Inactive()
        {
            throw new NotImplementedException();
        }

        public async Task OnBackground2InactiveAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Methods

        #endregion
    }
}