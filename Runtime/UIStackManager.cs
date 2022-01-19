using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UIStackVirtualHead : IUIPanelElement
    {
        public PanelState state => PanelState.Inactive;

        public void OnInitialization()
        {
            
        }

        public void OnInactive2Active()
        {
            
        }

        public void OnInactive2Background()
        {
            
        }

        public void OnBackground2Active()
        {
            
        }

        public void OnActive2Background()
        {
            
        }

        public async Task OnActive2BackgroundAsync()
        {
            return;
        }

        public void OnActive2Inactive()
        {
            
        }

        public async Task OnActive2InactiveAsync()
        {
            return;
        }

        public void OnBackground2Inactive()
        {
            
        }

        public async Task OnBackground2InactiveAsync()
        {
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

        private Dictionary<IUIPanelElement, int> _uiPanelIndex = new Dictionary<IUIPanelElement, int>();

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


        private void Start()
        {
            
        }

        #region UIStack Operation

        public void OpenPanel(IUIPanelElement panelElement)
        {
            // Check panel available
            if (!_uiPanelIndex.ContainsKey(panelElement))
            {
                throw new InvalidOperationException("Panel not available.");
            }
        }

        public async Task OpenPanelAsync(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public void ClosePanel(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        public async Task ClosePanelAsync(IUIPanelElement panelElement)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}