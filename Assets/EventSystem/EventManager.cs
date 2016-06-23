using Assets.ITSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Events;

namespace Assets.EventSystem
{   

    public class EventManager
    {
       
        #region Singleton
        private static EventManager instance;
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManager();
                    instance.init();
                }
                return instance;
            }
        }

        void init()
        {
            instance.events = new Dictionary<EventIdentifier, CustomEvent>();
        }


        #endregion
    
        #region customEventData

        private Dictionary<EventIdentifier, CustomEvent> events;

        public void AddListener(EventIdentifier eventName, UnityAction<customEventData> listener)
        {
            CustomEvent thisEvent = null;
            if (instance.events.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new CustomEvent();
                thisEvent.AddListener(listener);
                instance.events.Add(eventName, thisEvent);
            }
        }

        public void RemoveListener(EventIdentifier eventName, UnityAction<customEventData> listener)
        {
            if (events == null) return;
            CustomEvent thisEvent = null;
            if (instance.events.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }


        public void TriggerEvent(EventIdentifier eventName, customEventData _customEventData)
        {
            if (_customEventData == null)
            {
                _customEventData = new customEventData();
            }

            CustomEvent thisEvent = null;
            if (instance.events.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(_customEventData);
            }
        }

        #endregion

    }
}
