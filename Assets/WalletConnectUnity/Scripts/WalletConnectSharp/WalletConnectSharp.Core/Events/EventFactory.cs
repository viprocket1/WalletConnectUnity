using System;
using System.Collections.Generic;

namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// The EventFactory stores a mapping of all registered event types with their respective IEventProviders. 
    /// </summary>
    public class EventFactory
    {
        private static EventFactory _instance;
        
        private Dictionary<Type, IEventProvider> _eventProviders = new Dictionary<Type, IEventProvider>();

        /// <summary>
        /// The current instance of the EventFactory
        /// </summary>
        public static EventFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventFactory();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Register a new IEventProvider that can handle the given type T.
        ///
        /// If the type T is already registered, then nothing happens
        /// </summary>
        /// <param name="provider">The IEventProvider object that can process the type T</param>
        /// <typeparam name="T">The type the given IEventProvider object can process</typeparam>
        public void Register<T>(IEventProvider provider)
        {
            Type t = typeof(T);

            if (_eventProviders.ContainsKey(t))
                return;
            
            _eventProviders.Add(t, provider);
        }

        /// <summary>
        /// Get an IEventProvider for the given type T. If no IEventProvider has been registered that
        /// can handle the given type T, then null is returned
        /// </summary>
        /// <typeparam name="T">The type T that needs an IEventProvider</typeparam>
        /// <returns>An IEventProvider that can process the given type T</returns>
        public IEventProvider ProviderFor<T>()
        {
            Type t = typeof(T);
            if (_eventProviders.ContainsKey(t))
                return _eventProviders[t];

            return null;
        }
    }
}