using System.Collections;
using FinTOKMAK.UIStackSystem.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

namespace FinTOKMAK.UIStackSystem.Tests.Runtime
{
    public class UIPanelElementTest
    {
        #region Private Field

        private GameObject _panelObject;
        private UIPanelElement _panel;

        #endregion

        /// <summary>
        /// The UIPanelTest initialization.
        /// </summary>
        [SetUp]
        public void Init()
        {
            _panelObject = new GameObject();
            _panel = _panelObject.AddComponent<UIPanelElement>();
            
            _panel.inactive2ActiveEvent = new UnityEvent();
            _panel.inactive2BackgroundEvent = new UnityEvent();
            _panel.background2ActiveEvent = new UnityEvent();
            _panel.active2BackgroundEvent = new UnityEvent();
            _panel.active2InactiveEvent = new UnityEvent();
            _panel.background2InactiveEvent = new UnityEvent();
            _panel.finishActive2BackgroundEvent = new UnityEvent();
            _panel.finishActive2InactiveEvent = new UnityEvent();
            _panel.finishBackground2InactiveEvent = new UnityEvent();
            
            Debug.Log("UIPanelElement test initialized.");
        }

        [TearDown]
        public void CleanUp()
        {
            _panelObject = null;
            _panel = null;
            
            Debug.Log("UIPanelElement test cleaned up.");
        }
        
        
        /// <summary>
        /// Testing the initial status of a UIPanelElement.
        /// </summary>
        [Test]
        public void UIPanelElementTestInitStatus()
        {
            Assert.AreEqual(PanelState.Inactive, _panel.state);
        }

        /// <summary>
        /// Testing the panel state change from Inactive to Background.
        /// </summary>
        [Test]
        public void UIPanelElementTestInactive2Background()
        {
            // The bool check variable to check if the inactive2ActiveEvent is correctly triggered.
            bool inactive2BackgroundUnityEventTriggered = false;
            _panel.inactive2BackgroundEvent.AddListener(() =>
            {
                inactive2BackgroundUnityEventTriggered = true;
            });
            
            _panel.OnInactive2Background();
            
            Assert.IsTrue(inactive2BackgroundUnityEventTriggered);
        }
        
        /// <summary>
        /// Testing the panel state change from Inactive to Active.
        /// </summary>
        [Test]
        public void UIPanelElementTestInactive2Active()
        {
            // The bool check variable to check if the inactive2ActiveEvent is correctly triggered.
            bool inactive2ActiveUnityEventTriggered = false;
            _panel.inactive2ActiveEvent.AddListener(() =>
            {
                inactive2ActiveUnityEventTriggered = true;
            });
            
            _panel.OnInactive2Active();
            
            Assert.IsTrue(inactive2ActiveUnityEventTriggered);
        }
        
        /// <summary>
        /// Testing the panel state change from Background to Active.
        /// </summary>
        [Test]
        public void UIPanelElementTestBackground2Active()
        {
            // The bool check variable to check if the inactive2ActiveEvent is correctly triggered.
            bool background2ActiveUnityEventTriggered = false;
            _panel.background2ActiveEvent.AddListener(() =>
            {
                background2ActiveUnityEventTriggered = true;
            });
            
            _panel.OnBackground2Active();
            
            Assert.IsTrue(background2ActiveUnityEventTriggered);
        }
    }
}
