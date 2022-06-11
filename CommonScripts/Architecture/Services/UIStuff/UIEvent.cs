using System.Collections;
using UnityEngine.Events;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff
{
    public class UIEvent : UnityEvent<Hashtable>
    {
    }
    
    public enum UIEventType
    {
        GameStartedAction,
        GameFinishedAction,
    }
}