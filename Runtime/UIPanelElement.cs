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
    /// The event listener listening to the event invoker.
    /// Should be used by panels.
    /// </summary>
    [System.Serializable]
    public class UIEventListener
    {
        /// <summary>
        /// The UIEventInvoker current listener is listening to.
        /// Listener listening to different event may respond to different action.
        /// </summary>
        [InterfaceType(typeof(IUIEventInvoker))]
        public MonoBehaviour invoker;
        
        /// <summary>
        /// The finish status, true when event finished.
        /// </summary>
        public bool finishStatus;
    }

    /// <summary>
    /// Three standard panel state.
    /// </summary>
    public enum PanelState
    {
        Active,
        Background,
        Inactive
    }
    
    /// <summary>
    /// This is the base class for UIPanel
    /// All the UI panel logic class should inherit this class
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Panel Element")]
    public class UIPanelElement : MonoBehaviour, IUIPanelElement, IUIEventInvoker
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
        /// All the listeners listening to finishActive2Background action events.
        /// </summary>
        [BoxGroup("Event Listeners")]
        public List<UIEventListener> active2BackgroundListeners = new List<UIEventListener>();
        /// <summary>
        /// All the listeners listening to finishBackground2Inactive action events.
        /// </summary>
        [BoxGroup("Event Listeners")]
        public List<UIEventListener> background2InactiveListeners = new List<UIEventListener>();
        /// <summary>
        /// All the listeners listening to finishActive2Inactive action events.
        /// </summary>
        [BoxGroup("Event Listeners")]
        public List<UIEventListener> active2InactiveListeners = new List<UIEventListener>();

        [BoxGroup("UI Stack Event")]
        public UnityEvent panelInitialize;
        [BoxGroup("Ascending Event")]
        public UnityEvent inactive2ActiveEvent;
        [BoxGroup("Ascending Event")]
        public UnityEvent inactive2BackgroundEvent;
        [BoxGroup("Ascending Event")]
        public UnityEvent background2ActiveEvent;
        [BoxGroup("Descending Event")]
        public UnityEvent active2BackgroundEvent;
        [BoxGroup("Descending Event")]
        public UnityEvent finishActive2BackgroundEvent;
        [BoxGroup("Descending Event")]
        public UnityEvent background2InactiveEvent;
        [BoxGroup("Descending Event")]
        public UnityEvent finishBackground2InactiveEvent;
        [BoxGroup("Descending Event")]
        public UnityEvent active2InactiveEvent;
        [BoxGroup("Descending Event")]
        public UnityEvent finishActive2InactiveEvent;
        
        #endregion

        #region Hide Public Field

        public PanelState state => _state;

        #endregion

        #region Private Field

        /// <summary>
        /// The standard state of current panel.
        /// </summary>
        private PanelState _state;
        
        /// <summary>
        /// The async TaskCompleteSource for active2BackgroundListeners
        /// </summary>
        private TaskCompletionSource<bool> _active2BackgroundComplete = new TaskCompletionSource<bool>();
        /// <summary>
        /// The async TaskCompleteSource for background2InactiveListeners
        /// </summary>
        private TaskCompletionSource<bool> _active2InactiveComplete = new TaskCompletionSource<bool>();
        /// <summary>
        /// The async TaskCompleteSource for active2InactiveListeners
        /// </summary>
        private TaskCompletionSource<bool> _background2InactiveComplete = new TaskCompletionSource<bool>();

        #endregion

        private void Awake()
        {
            RegisterActive2BackgroundEvents();
            RegisterActive2InactiveEvents();
            RegisterBackground2InactiveEvents();
        }
        
        private void OnEnable()
        {
            
        }

        #region Event Helper

        /// <summary>
        /// Call this method to register logic into all active2BackgroundListeners.
        /// </summary>
        private void RegisterActive2BackgroundEvents()
        {
            foreach (UIEventListener eventListener in active2BackgroundListeners)
            {
                // Register the logic for all the listening event invoker.
                ((IUIEventInvoker) eventListener.invoker).finishActive2Background += () =>
                {
                    eventListener.finishStatus = true;
                    // If all the event invoker has finish status, invoke the finishActive2Background in current panel.
                    if (AllActive2BackgroundFinished())
                    {
                        _active2BackgroundComplete.SetResult(true);
                        finishActive2Background?.Invoke();
                    }
                };
            }
        }

        /// <summary>
        /// Call this method to check if all the active2BackgroundListeners have finished events.
        /// </summary>
        /// <returns>true if all the active2BackgroundListeners finished events.</returns>
        private bool AllActive2BackgroundFinished()
        {
            foreach (UIEventListener eventListener in active2BackgroundListeners)
            {
                if (!eventListener.finishStatus)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Call this method to reset all the active2BackgroundListeners status.
        /// </summary>
        private void ResetActive2BackgroundEvents()
        {
            foreach (UIEventListener eventListener in active2BackgroundListeners)
            {
                eventListener.finishStatus = false;
            }
        }
        
        /// <summary>
        /// Call this method to register logic into all active2InactiveListeners.
        /// </summary>
        private void RegisterActive2InactiveEvents()
        {
            foreach (UIEventListener eventListener in active2InactiveListeners)
            {
                // Register the logic for all the listening event invoker.
                ((IUIEventInvoker) eventListener.invoker).finishActive2Inactive += () =>
                {
                    eventListener.finishStatus = true;
                    // If all the event invoker has finish status, invoke the finishActive2Inactive in current panel.
                    if (AllActive2InactiveFinished())
                    {
                        _active2InactiveComplete.SetResult(true);
                        finishActive2Inactive?.Invoke();
                    }
                };
            }
        }

        /// <summary>
        /// Call this method to check if all the active2InactiveListeners have finished events.
        /// </summary>
        /// <returns>true if all the active2InactiveListeners finished events.</returns>
        private bool AllActive2InactiveFinished()
        {
            foreach (UIEventListener eventListener in active2InactiveListeners)
            {
                if (!eventListener.finishStatus)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Call this method to reset all the active2InactiveListeners status.
        /// </summary>
        private void ResetActive2InactiveEvents()
        {
            foreach (UIEventListener eventListener in active2InactiveListeners)
            {
                eventListener.finishStatus = false;
            }
        }
        
        /// <summary>
        /// Call this method to register logic into all background2InactiveListeners.
        /// </summary>
        private void RegisterBackground2InactiveEvents()
        {
            foreach (UIEventListener eventListener in background2InactiveListeners)
            {
                // Register the logic for all the listening event invoker.
                ((IUIEventInvoker) eventListener.invoker).finishBackground2Inactive += () =>
                {
                    eventListener.finishStatus = true;
                    // If all the event invoker has finish status, invoke the finishBackground2Inactive in current panel.
                    if (AllBackground2InactiveFinished())
                    {
                        _background2InactiveComplete.SetResult(true);
                        finishBackground2Inactive?.Invoke();
                    }
                };
            }
        }

        /// <summary>
        /// Call this method to check if all the background2InactiveListeners have finished events.
        /// </summary>
        /// <returns>true if all the background2InactiveListeners finished events.</returns>
        private bool AllBackground2InactiveFinished()
        {
            foreach (UIEventListener eventListener in background2InactiveListeners)
            {
                if (!eventListener.finishStatus)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Call this method to reset all the background2InactiveListeners status.
        /// </summary>
        private void ResetBackground2InactiveEvents()
        {
            foreach (UIEventListener eventListener in background2InactiveListeners)
            {
                eventListener.finishStatus = false;
            }
        }

        #endregion

        #region IUIPanelElement Callback

        public void OnInitialization()
        {
            _state = PanelState.Inactive;
            gameObject.SetActive(false);
            panelInitialize?.Invoke();
        }

        public void OnInactive2Active()
        {
            // Invoke the UnityEvent
            inactive2ActiveEvent?.Invoke();
            // Reset all event listeners associated with Active state
            ResetActive2BackgroundEvents();
            ResetActive2InactiveEvents();
            
            // Set current state.
            _state = PanelState.Active;
        }

        public void OnInactive2Background()
        {
            // Invoke UnityEvent
            inactive2BackgroundEvent?.Invoke();
            // Reset all event listeners associated with Background state
            ResetBackground2InactiveEvents();
            
            // Set current State
            _state = PanelState.Background;
        }

        public void OnBackground2Active()
        {
            // Invoke the UnityEvent
            background2ActiveEvent?.Invoke();
            // Reset all event listeners associated with Active state
            ResetActive2BackgroundEvents();
            ResetActive2InactiveEvents();
            
            // Set current state.
            _state = PanelState.Active;
        }

        public void OnActive2Background()
        {
            // Invoke the UnityEvent
            active2BackgroundEvent?.Invoke();
            
            finishActive2Background?.Invoke();
            
            // Reset all event listeners associated with Background state
            ResetBackground2InactiveEvents();
            
            // Set current State
            _state = PanelState.Background;
        }

        public async Task OnActive2BackgroundAsync()
        {
            // Invoke the UnityEvent
            active2BackgroundEvent?.Invoke();

            if (!AllActive2BackgroundFinished())
            {
                // Wait all the events finish.
                await _active2BackgroundComplete.Task;
                _active2BackgroundComplete = new TaskCompletionSource<bool>();
            }
            
            finishActive2BackgroundEvent?.Invoke();
            
            // Reset all event listeners associated with Background state
            ResetBackground2InactiveEvents();
            
            // Set current State
            _state = PanelState.Background;
        }

        public void OnActive2Inactive()
        {
            // Invoke the UnityEvent
            active2InactiveEvent?.Invoke();
            
            finishActive2InactiveEvent?.Invoke();

            // Set current State
            _state = PanelState.Inactive;
        }

        public async Task OnActive2InactiveAsync()
        {
            // Invoke the UnityEvent
            active2InactiveEvent?.Invoke();

            if (!AllActive2InactiveFinished())
            {
                await _active2InactiveComplete.Task;
                _active2InactiveComplete = new TaskCompletionSource<bool>(); 
            }
            
            finishActive2InactiveEvent?.Invoke();

            // Set current State
            _state = PanelState.Inactive;
        }

        public void OnBackground2Inactive()
        {
            // Invoke the UnityEvent
            background2InactiveEvent?.Invoke();
            
            finishBackground2InactiveEvent?.Invoke();
            
            // Set current State
            _state = PanelState.Inactive;
        }

        public async Task OnBackground2InactiveAsync()
        {
            // Invoke the UnityEvent
            background2InactiveEvent?.Invoke();

            if (!AllBackground2InactiveFinished())
            {
                await _background2InactiveComplete.Task;
                _background2InactiveComplete = new TaskCompletionSource<bool>();
            }
            
            finishBackground2InactiveEvent?.Invoke();

            // Set current State
            _state = PanelState.Inactive;
        }

        #endregion

        #region IUIEventInvoker

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

        #endregion

        #region Debug

        

        #endregion
    }
}