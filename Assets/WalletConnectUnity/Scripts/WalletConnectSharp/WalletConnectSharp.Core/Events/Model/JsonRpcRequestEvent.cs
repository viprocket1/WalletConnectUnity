using WalletConnectSharp.Core.Models;

namespace WalletConnectSharp.Core.Events.Response
{
    /// <summary>
    /// Represents a generic event holding a JsonRpcRequest object. 
    /// </summary>
    /// <typeparam name="T">The type of JsonRpcRequest object this event holds</typeparam>
    public class JsonRpcRequestEvent<T> : GenericEvent<T> where T : JsonRpcRequest
    {
    }
}