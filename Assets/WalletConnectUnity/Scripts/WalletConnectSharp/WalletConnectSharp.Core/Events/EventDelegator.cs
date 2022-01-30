using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WalletConnectSharp.Core.Events.Request;
using WalletConnectSharp.Core.Events.Response;
using WalletConnectSharp.Core.Models;

namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// The EventDelegator handles the propagation of event triggers to their subscribers. Any subscriber that wishes
    /// to listen for a specific event with a given {eventId} string can call a ListenFor() function giving the
    /// eventId string to listen for and a callback to invoke. This is similar to Javascript's .on() function.
    ///
    /// An eventId can be triggered directly using the Trigger function where either a raw JSON string of the event
    /// argument data is passed or a managed object.
    ///
    /// Listening for an event stores the callback in an EventManager of the given callback type, and creates
    /// a callback type provider in the EventFactory.
    ///
    /// This essentially means that the callback type used must be what is expected for the given {eventId}, as
    /// if the raw JSON cannot be mapped to the callback type used then an exception will be thrown.
    /// </summary>
    public class EventDelegator : IDisposable
    {
        private Dictionary<string, List<IEventProvider>> Listeners = new Dictionary<string, List<IEventProvider>>();

        /// <summary>
        /// Listen for a response Event of a generic type. The request id given will genearte
        /// an eventId with the following format `response:{id}`
        /// </summary>
        /// <param name="id">The request ID to listen for a response for</param>
        /// <param name="callback">The callback to invoke for this Event triggering</param>
        /// <typeparam name="T">The type of data that will be passed to the event trigger callback</typeparam>
        public void ListenForGenericResponse<T>(object id, EventHandler<GenericEvent<T>> callback)
        {
            ListenFor("response:" + id, callback);
        }

        /// <summary>
        /// Listen for a response Event of a JsonRpcEvent type. The request id given will genearte
        /// an eventId with the following format `response:{id}`
        /// </summary>
        /// <param name="id">The request ID to listen for a response for</param>
        /// <param name="callback">The callback to invoke for this Event triggering</param>
        /// <typeparam name="T">The type of data that will be passed to the event trigger callback</typeparam>
        public void ListenForResponse<T>(object id, EventHandler<JsonRpcEvent<T>> callback) where T : JsonRpcResponse
        {
            ListenFor("response:" + id, callback);
        }

        public void ListenFor<T>(string eventId, EventHandler<GenericEvent<T>> callback)
        {  
            EventManager<T, GenericEvent<T>>.Instance.EventTriggers[eventId] += callback;

            SubscribeProvider(eventId, EventFactory.Instance.ProviderFor<T>());
        }
        
        public void ListenFor<T>(string eventId, EventHandler<JsonRpcEvent<T>> callback) where T : JsonRpcResponse
        {
            EventManager<T, JsonRpcEvent<T>>.Instance.EventTriggers[eventId] += callback;
            
            SubscribeProvider(eventId, EventFactory.Instance.ProviderFor<T>());
        }

        public void ListenFor<T>(string eventId, EventHandler<JsonRpcRequestEvent<T>> callback) where T : JsonRpcRequest
        {
            EventManager<T, JsonRpcRequestEvent<T>>.Instance.EventTriggers[eventId] += callback;

            SubscribeProvider(eventId, EventFactory.Instance.ProviderFor<T>());
        }

        private void SubscribeProvider(string eventId, IEventProvider provider)
        {
            List<IEventProvider> listProvider;
            if (!Listeners.ContainsKey(eventId))
            {
                //Debug.Log("Adding new EventProvider list for " + eventId);
                listProvider = new List<IEventProvider>();
                Listeners.Add(eventId, listProvider);
            }
            else
            {
                listProvider = Listeners[eventId];
            }
            listProvider.Add(provider);
        }
        
        public bool Trigger<T>(string topic, T obj)
        {
            return Trigger(topic, JsonConvert.SerializeObject(obj));
        }


        public bool Trigger(string topic, string json)
        {
            if (Listeners.ContainsKey(topic))
            {
                var providerList = Listeners[topic];

                for (int i = 0; i < providerList.Count; i++)
                {
                    var provider = providerList[i];
                    
                    provider.PropagateEvent(topic, json);
                }

                return providerList.Count > 0;
            }

            return false;
        }

        public void Dispose()
        {
            Clear();
        }

        public void Clear()
        {
            Listeners.Clear();
        }
    }
}