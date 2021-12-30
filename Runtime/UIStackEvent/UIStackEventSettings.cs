using FinTOKMAK.EventSystem.Runtime;
using Hextant;
using UnityEditor;
#if UNITY_EDITOR
using Hextant.Editor;
#endif

namespace FinTOKMAK.UIStackSystem.Runtime.UIStackEvent
{
    /// <summary>
    /// The Event settings for UI Stack System.
    /// </summary>
    [Settings( SettingsUsage.RuntimeProject, "FinTOKMAK Global Event" )]
    public class UIStackEventSettings : Settings<UIStackEventSettings>
    {
        public UniversalEventConfig universalEventConfig;
        
#if UNITY_EDITOR
        [SettingsProvider]
        static SettingsProvider GetSettingsProvider() =>
            instance.GetSettingsProvider();
#endif
    }
}