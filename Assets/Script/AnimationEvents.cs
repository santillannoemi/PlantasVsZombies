using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]
    private List<AnimationEventsData> animationEvents;
    public void TriggerEvents(string eventName)
    {
        AnimationEventsData eventsData = animationEvents.Find(e => e.eventName == eventName);
        eventsData?.callback.Invoke();
    }
}
[System.Serializable]
public class AnimationEventsData
{
    public string eventName;
    public UnityEvent callback;
}
