using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UIStackVirtualHead : IUIPanelElement
    {
        private PanelState _state = PanelState.Background;
        
        public PanelState state => _state;

        public void OnInitialization()
        {
            
        }

        public void OnInactive2Active()
        {
            _state = PanelState.Active;
        }

        public void OnInactive2Background()
        {
            _state = PanelState.Background;
        }

        public void OnBackground2Active()
        {
            _state = PanelState.Active;
        }

        public void OnActive2Background()
        {
            _state = PanelState.Background;
        }

        public async Task OnActive2BackgroundAsync()
        {
            _state = PanelState.Background;
            return;
        }

        public void OnActive2Inactive()
        {
            _state = PanelState.Inactive;
        }

        public async Task OnActive2InactiveAsync()
        {
            _state = PanelState.Inactive;
            return;
        }

        public void OnBackground2Inactive()
        {
            _state = PanelState.Inactive;
        }

        public async Task OnBackground2InactiveAsync()
        {
            _state = PanelState.Inactive;
            return;
        }
    }
    
    /// <summary>
    /// This is the Stack Manager for the UI Stack System
    /// This MonoBehaviour should be attached to every root GameObject of UIPanelElements
    /// </summary>
    [AddComponentMenu("FinTOKMAK/UI Stack System/UI Stack Manager")]
    public class UIStackManager : UIManager, IUIPanelStack
    {
        #region Public Field



        #endregion

        #region Private Field

        /// <summary>
        /// The head of the UI Stack.
        /// </summary>
        private UINode<IUIPanelElement> _stackHead;

        /// <summary>
        /// The top of the stack.
        /// </summary>
        private UINode<IUIPanelElement> _top;

        /// <summary>
        /// The index of the stack top.
        /// </summary>
        private int _topIndex;

        /// <summary>
        /// The dictionary that maps panel to its index.
        /// </summary>
        private Dictionary<IUIPanelElement, int> _uiPanelIndex = new Dictionary<IUIPanelElement, int>();

        /// <summary>
        /// The dictionary that maps panel to its node.
        /// </summary>
        private Dictionary<IUIPanelElement, UINode<IUIPanelElement>> _uiPanelNodes =
            new Dictionary<IUIPanelElement, UINode<IUIPanelElement>>();

        #endregion

        private void Awake()
        {
            UINode<IUIPanelElement> virtualHead = new UINode<IUIPanelElement>()
            {
                value = new UIStackVirtualHead()
            };
            // Set the stack head and the stack top.
            _stackHead = virtualHead;
            _top = virtualHead;
            _topIndex = 0;
            _uiPanelIndex.Add(virtualHead.value, 0);
            _uiPanelNodes.Add(virtualHead.value, virtualHead);

            UINode<IUIPanelElement> curr = virtualHead;
            // Push all the panels to the stack.
            for (int i = UIPanels.Count-1; i >= 0; i--)
            {
                UINode<IUIPanelElement> node = new UINode<IUIPanelElement>()
                {
                    value = UIPanels[i]
                };
                curr.next = node;
                node.prev = curr;

                // Record the index
                _uiPanelIndex.Add(UIPanels[i], UIPanels.Count - i);
                _uiPanelNodes.Add(UIPanels[i], node);
                
                // Call the panel initialize.
                UIPanels[i].OnInitialization();
                
                // Panel initialization
                if (useInitializePanel && UIPanels[i] == initializationPanel)
                {
                    _top = node;
                    _topIndex = UIPanels.Count - i;
                }
                
                curr = node;
            }
            
            // Set the top panel to active.
            _top.value.OnInactive2Active();
        }

        #region UIStack Operation

        public void OpenPanel(IUIPanelElement panelElement)
        {
            // Check panel available
            if (!_uiPanelIndex.ContainsKey(panelElement))
            {
                throw new InvalidOperationException("Panel not available.");
            }
            
            // Check if the panel is already the top.
            if (_top.value == panelElement)
            {
                Debug.LogWarning("Panel already open.");
                return;
            }

            if (_uiPanelIndex[panelElement] > _topIndex)
            {
                // Close the top panel.
                _top.value.OnActive2Background();
                // Open the new panel.
                panelElement.OnInactive2Active();
                // Update the stack top pointer and index.
                _top = _uiPanelNodes[panelElement];
                _topIndex = _uiPanelIndex[panelElement];
            }
            else
            {
                // Switch panel to background.
                panelElement.OnInactive2Background();
            }
        }

        public async Task OpenPanelAsync(IUIPanelElement panelElement)
        {
            // Check panel available
            if (!_uiPanelIndex.ContainsKey(panelElement))
            {
                throw new InvalidOperationException("Panel not available.");
            }
            
            // Check if the panel is already the top.
            if (_top.value == panelElement)
            {
                Debug.LogWarning("Panel already open.");
                return;
            }

            if (_uiPanelIndex[panelElement] > _topIndex)
            {
                // Close the top panel.
                await _top.value.OnActive2BackgroundAsync();
                // Open the new panel.
                panelElement.OnInactive2Active();
                // Update the stack top pointer and index.
                _top = _uiPanelNodes[panelElement];
                _topIndex = _uiPanelIndex[panelElement];
            }
            else
            {
                // Switch panel to background.
                panelElement.OnInactive2Background();
            }
        }

        public void ClosePanel(IUIPanelElement panelElement)
        {
            // Check panel available
            if (!_uiPanelIndex.ContainsKey(panelElement))
            {
                throw new InvalidOperationException("Panel not available.");
            }
            
            // Check if the panel is already closed.
            if (panelElement.state == PanelState.Inactive)
            {
                Debug.Log("Panel already closed.");
                return;
            }
            
            // If the target panel is the stack top.
            // Check if the panel is already the top.
            if (_top.value == panelElement)
            {
                _top.value.OnActive2Inactive();
                // Try to find the new highest
                while (_top.prev != null)
                {
                    _top = _top.prev;
                    if (_top.value.state == PanelState.Background)
                        break;
                }
                _top.value.OnBackground2Active();
            }
            else
            {
                panelElement.OnBackground2Inactive();
            }
        }

        public async Task ClosePanelAsync(IUIPanelElement panelElement)
        {
            // Check panel available
            if (!_uiPanelIndex.ContainsKey(panelElement))
            {
                throw new InvalidOperationException("Panel not available.");
            }
            
            // Check if the panel is already closed.
            if (panelElement.state == PanelState.Inactive)
            {
                Debug.Log("Panel already closed.");
                return;
            }
            
            // If the target panel is the stack top.
            // Check if the panel is already the top.
            if (_top.value == panelElement)
            {
                await _top.value.OnActive2InactiveAsync();
                // Try to find the new highest
                while (_top.prev != null)
                {
                    _top = _top.prev;
                    if (_top.value.state == PanelState.Background)
                        break;
                }
                _top.value.OnBackground2Active();
            }
            else
            {
                await panelElement.OnBackground2InactiveAsync();
            }
        }

        #endregion
    }
}