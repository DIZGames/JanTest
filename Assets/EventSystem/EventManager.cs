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
            instance.events = new Dictionary<string, CustomEvent>();
            instance.eventsItem = new Dictionary<string, ItemEvent>();
        }


        #endregion

        #region customEventData

        private Dictionary<string, CustomEvent> events;

        public void AddListener(string eventName, UnityAction<customEventData> listener)
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

        public void RemoveListener(string eventName, UnityAction<customEventData> listener)
        {
            if (events == null) return;
            CustomEvent thisEvent = null;
            if (instance.events.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }


        public void TriggerEvent(string eventName, customEventData _customEventData)
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

        #region Item

        private Dictionary<string, ItemEvent> eventsItem;

        public void AddListener(string eventName, UnityAction<Item> listener)
        {
            ItemEvent thisEvent = null;
            if (instance.eventsItem.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new ItemEvent();
                thisEvent.AddListener(listener);
                instance.eventsItem.Add(eventName, thisEvent);
            }
        }

        public void RemoveListener(string eventName, UnityAction<Item> listener)
        {
            if (events == null) return;
            ItemEvent thisEvent = null;
            if (instance.eventsItem.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }


        public void TriggerEvent(string eventName, Item _Item)
        {
            if (_Item == null)
            {
                _Item = new Item();
            }

            ItemEvent thisEvent = null;
            if (instance.eventsItem.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(_Item);
            }
        }

        #endregion

    }
}
