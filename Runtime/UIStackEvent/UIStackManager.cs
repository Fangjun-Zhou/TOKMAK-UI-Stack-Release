﻿using FinTOKMAK.EventSystem.Runtime;
using FinTOKMAK.EventSystem.Runtime.GlobalEvent;
using Hextant;

namespace FinTOKMAK.UIStackSystem.Runtime.UIStackEvent
{
    public class UIStackManager: UniversalEventManager
    {
        public override UniversalEventConfig GetEventConfig()
        {
            return Settings<GlobalEventSettings>.instance.universalEventConfig;
        }
    }
}