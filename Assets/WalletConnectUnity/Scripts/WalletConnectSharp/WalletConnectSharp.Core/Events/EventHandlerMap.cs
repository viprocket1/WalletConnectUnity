using System;
using System.Collections.Generic;

namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// A mapping of strings to EventHandlers with the given TEventArgs event arguments. 
    /// </summary>
    /// <typeparam name="TEventArgs">The event argument type the EventHandler should have</typeparam>
    public class EventHandlerMap<TEventArgs>
    {
        private Dictionary<string, EventHandler<TEventArgs>> mapping =
            new Dictionary<string, EventHandler<TEventArgs>>();

        private EventHandler<TEventArgs> BeforeEventExecuted;

        public EventHandlerMap(EventHandler<TEventArgs> callbackBeforeExecuted)
        {
            if (callbackBeforeExecuted == null)
            {
                callbackBeforeExecuted = CallbackBeforeExecuted;
            }

            this.BeforeEventExecuted = callbackBeforeExecuted;
        }

        private void CallbackBeforeExecuted(object sender, TEventArgs e)
        {
        }

        /// <summary>
        /// Get the EventHandler for the given string id
        /// </summary>
        /// <param name="key">The string ID key</param>
        public EventHandler<TEventArgs> this[string key]
        {
            get
            {
                if (!mapping.ContainsKey(key))
                {
                    mapping.Add(key, BeforeEventExecuted);
                }
                
                return mapping[key];
            }
            set
            {
                if (mapping.ContainsKey(key))
                {
                    mapping.Remove(key);
                }
                
                mapping.Add(key, value);
            }
        }

        /// <summary>
        /// Whether this mapping contains an EventHandler for the given string key
        /// </summary>
        /// <param name="key">The string key to check</param>
        /// <returns>True if the key given has an EventHandler, false otherwise</returns>
        public bool Contains(string key)
        {
            return mapping.ContainsKey(key);
        }
    }
}