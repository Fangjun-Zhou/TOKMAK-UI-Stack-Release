using FinTOKMAK.EventSystem.Editor;
using FinTOKMAK.EventSystem.Runtime;
using FinTOKMAK.UIStackSystem.Runtime.UIStackEvent;
using Hextant;
using UnityEditor;

namespace Package.Editor.UIStackEvent
{
    [CustomPropertyDrawer(typeof(UIStackEventAttribute))]
    public class GlobalEventDrawer: UniversalEventDrawer
    {
        public override UniversalEventConfig GetEventConfig()
        {
            return Settings<UIStackEventSettings>.instance.universalEventConfig;
        }
    }
}