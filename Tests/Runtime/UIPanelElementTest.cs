using System.Collections;
using FinTOKMAK.UIStackSystem.Runtime;
using NUnit.Framework;
using UnityEngine;
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
            
            Debug.Log("UIPanelElement test initialized.");
        }

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
        
        
    }
}
