using WalletConnectSharp.Core.Models;

namespace WalletConnectSharp.Core.Events.Request
{
    /// <summary>
    /// Represents a generic event holding a JsonRpcResponse object. 
    /// </summary>
    /// <typeparam name="T">The type of JsonRpcResponse object this event holds</typeparam>
    public class JsonRpcEvent<T> : GenericEvent<T> where T : JsonRpcResponse
    {
    }
}