namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// An IEventProvider is a provider that can process specific events with raw
    /// JSON string
    /// </summary>
    public interface IEventProvider
    {
        /// <summary>
        /// Propagate a specific event with the given raw JSON data
        /// </summary>
        /// <param name="topic">The event to propagate</param>
        /// <param name="responseJson">The raw event data as a JSON string</param>
        void PropagateEvent(string topic, string responseJson);
    }
}