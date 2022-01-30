using Newtonsoft.Json;

namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A container for responses to most/all JsonRpcRequests sent
    /// </summary>
    public class EthResponse : JsonRpcResponse
    {
        [JsonProperty]
        private string result;

        [JsonIgnore]
        public string Result => result;
    }
}