using Newtonsoft.Json;

namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A JsonRpcRequest that represents eth_sign rpc method
    /// </summary>
    public sealed class EthSign : JsonRpcRequest
    {
        [JsonProperty("params")] 
        private string[] _parameters;

        [JsonIgnore]
        public string[] Parameters => _parameters;

        public EthSign(string address, string hexData) : base()
        {
            this.Method = "eth_sign";
            this._parameters = new[] {address, hexData};
        }
    }
}