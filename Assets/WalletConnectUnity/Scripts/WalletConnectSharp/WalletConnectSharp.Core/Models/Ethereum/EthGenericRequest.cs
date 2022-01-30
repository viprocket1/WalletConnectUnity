using Newtonsoft.Json;

namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A generic JsonRpcRequest to represent the common
    /// format shared among ETH RPC Requests
    /// </summary>
    /// <typeparam name="T">The type this JsonRpcRequest parameters are</typeparam>
    public sealed class EthGenericRequest<T> : JsonRpcRequest
    {
        [JsonProperty("params")] 
        private T[] _parameters;

        [JsonIgnore]
        public T[] Parameters => _parameters;

        public EthGenericRequest(string jsonRpcMethodName, params T[] data) : base()
        {
            this.Method = jsonRpcMethodName;
            this._parameters = data;
        }
    }
}