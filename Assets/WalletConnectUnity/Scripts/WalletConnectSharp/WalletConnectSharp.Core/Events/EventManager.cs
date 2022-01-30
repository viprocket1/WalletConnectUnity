using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// The EventManager is a generic IEventProvider that can process event data for the given type T. When
    /// the IEventProvider is given an event with data to propagate, it'll transform the data to the provided
    /// type T, and trigger an EventHandler wrapping the transformed data into the EventHandler's TEventArgs
    /// </summary>
    /// <typeparam name="T">The type T this IEventProvider can process</typeparam>
    /// <typeparam name="TEventArgs">The TEventArgs that should be passed when triggering the event</typeparam>
    public class EventManager<T, TEventArgs> : IEventProvider where TEventArgs : IEvent<T>, new()
    {
        private static EventManager<T, TEventArgs> _instance;

        public EventHandlerMap<TEventArgs> EventTriggers;

        public static EventManager<T, TEventArgs> Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new EventManager<T, TEventArgs>();
                }
                
                return _instance; 
            }
        }

        private EventManager()
        {
            EventTriggers = new EventHandlerMap<TEventArgs>(CallbackBeforeExecuted);
            
            EventFactory.Instance.Register<T>(this);
        }
        
        private void CallbackBeforeExecuted(object sender, TEventArgs e)
        {
        }

        public void PropagateEvent(string topic, string responseJson)
        {
            if (EventTriggers.Contains(topic))
            {
                var eventTrigger = EventTriggers[topic];

                if (eventTrigger != null)
                {
                    var response = JsonConvert.DeserializeObject<T>(responseJson);
                    var eventArgs = new TEventArgs();
                    eventArgs.SetData(response);
                    eventTrigger(this, eventArgs);
                }
            }
        }
    }
}