namespace WalletConnectSharp.Core.Events
{
    /// <summary>
    /// Represents an Event that can store data of type T 
    /// </summary>
    /// <typeparam name="T">The type of data this event stores</typeparam>
    public interface IEvent<in T>
    {
        
        void SetData(T data);
    }
}