using System;
using System.Linq;
using FinTOKMAK.UIStackSystem.Runtime;
using UnityEditor;
using UnityEngine;

namespace Package.Editor
{
    public class UIStackManagerCustomEditor : UnityEditor.Editor
    {
        #region Private Field

        private UIManager _stackManager;

        #region Serializaed Property

        private SerializedProperty _uiPanels;
        private SerializedProperty _initializationPanel;

        #endregion

        private bool _containInitializationPanel;

        #endregion

        private void OnEnable()
        {
            _stackManager = (UIManager) serializedObject.targetObject;

            _uiPanels = serializedObject.FindProperty("UIPanels");
            _initializationPanel = serializedObject.FindProperty("initializationPanel");
            
            CheckInitializationPanel();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            #region UI Panels

            EditorGUILayout.LabelField("UI Panels", EditorStyles.boldLabel);
            
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");
            {
                EditorGUILayout.PropertyField(_uiPanels);
            }
            EditorGUILayout.EndVertical();
            if (EditorGUI.EndChangeCheck())
            {
                // Assign current manager to all the panels.
                UpdatePanelRoot();
            }
                
            serializedObject.ApplyModifiedProperties();

            #endregion

            #region Initialization Panel

            EditorGUILayout.LabelField("Initialization Panel", EditorStyles.boldLabel);

            _stackManager.useInitializePanel =
                EditorGUILayout.Toggle("Has Initialization Panel", _stackManager.useInitializePanel);
            if (_stackManager.useInitializePanel)
            {
                EditorGUI.BeginChangeCheck();
                {
                    EditorGUILayout.BeginVertical("Box");
                    {
                        EditorGUILayout.PropertyField(_initializationPanel);
                        
                        if (!_containInitializationPanel)
                        {
                            EditorGUILayout.HelpBox(
                                "Your initialization panel is not in the UIPanels! Add to your UIPanels first!",
                                MessageType.Error);
                        }
                    }
                    EditorGUILayout.EndVertical();
                    
                    serializedObject.ApplyModifiedProperties();
                }
                if (EditorGUI.EndChangeCheck())
                {
                    CheckInitializationPanel();
                }
            }

            #endregion
            
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Check if the initialization panel is in the UIPanels list
        /// </summary>
        private void CheckInitializationPanel()
        {
            if (_stackManager.initializationPanel == null ||
                !_stackManager.UIPanels.Contains(_stackManager.initializationPanel))
            {
                _containInitializationPanel = false;
            }
            else
            {
                _containInitializationPanel = true;
            }
        }

        /// <summary>
        /// Call this method to update the root manager of all the panel managed by current manager.
        /// </summary>
        private void UpdatePanelRoot()
        {
            foreach (UIPanelElement panel in _stackManager.UIPanels)
            {
                panel.panelRootManager = _stackManager;
            }
        }
    }
}