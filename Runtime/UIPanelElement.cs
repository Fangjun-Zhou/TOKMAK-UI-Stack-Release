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
    public class UIPanelElement : MonoBehaviour, IUIStackEventInvoker, IUIPanelElement
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
        
        /// <summary>
        /// All the listeners current UIPanelElement is listening to.
        /// </summary>
        [BoxGroup("UI Finish Listeners")]
        [ReorderableList]
        public List<UIStackEventListener> listeners;

        [BoxGroup("UI Stack Event")]
        public UnityEvent pushEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent popEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishPopEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent pauseEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent finishPauseEvent;
        [BoxGroup("UI Stack Event")]
        public UnityEvent resumeEvent;
        
        public Action finishAction { get; set; }
        #endregion

        private void Awake()
        {
            // By default the panel element should be inactivate
            gameObject.SetActive(false);
            
            // initialize listeners
            foreach (UIStackEventListener listener in listeners)
            {
                ((IUIStackEventInvoker) listener.eventInvoker).finishAction += () =>
                {
                    // when finish action is triggered
                    
                    // set the state to finished
                    listener.state = true;
                    // check all the finish state and trigger the FinishAction in the panel
                    FinishCheck();
                };
            }
        }
        
        private void OnEnable()
        {
            foreach (UIStackEventListener listener in listeners)
            {
                listener.state = false;
            }
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

        /// <summary>
        /// Check all the listeners' state and trigger the finish event if all the listeners are finished
        /// </summary>
        public void FinishCheck()
        {
            // if all the UIStackEventListeners are finished, call the finish pause event

            foreach (UIStackEventListener listener in listeners)
            {
                if (!listener.state)
                    return;
            }
            
            finishAction?.Invoke();
        }

        [Button("UI Active Setup")]
        public void UIActiveSetup()
        {
            UnityAction methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectActive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (pushEvent, methodDelegate);
#endif
            
            methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectInactive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (finishPopEvent, methodDelegate);
#endif
            
            methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectInactive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (finishPauseEvent, methodDelegate);
#endif
            
            methodDelegate =
                System.Delegate.CreateDelegate(typeof(UnityAction), this, "SetGameObjectActive") as UnityAction;
#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener (resumeEvent, methodDelegate);
#endif
        }

        public void SetGameObjectActive()
        {
            gameObject.SetActive(true);
        }
        
        public void SetGameObjectInactive()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}