using System;

namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// Represents a generic event holding data of type T. 
    /// </summary>
    /// <typeparam name="T">The type of data his event holds</typeparam>
    public class GenericEvent<T> : IEvent<T>
    {
        /// <summary>
        /// The data associated with this Event
        /// </summary>
        public T EventData { get; private set; }

        /// <summary>
        /// Set the data associated with this Event. If this event already has data, then throw an
        /// ArgumentException
        /// </summary>
        /// <param name="data">The new data to attach to this Event</param>
        /// <exception cref="ArgumentException">If data is already attached to this event</exception>
        public void SetData(T data)
        {
            if (EventData != null)
            {
                throw new ArgumentException("Response was already set");
            }
            
            EventData = data;
        }
    }
}