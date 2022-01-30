using Newtonsoft.Json;

namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A JsonRpcRequest that represents eth_signTransaction rpc method
    /// </summary>
    public sealed class EthSignTransaction : JsonRpcRequest
    {
        [JsonProperty("params")] 
        private TransactionData[] _parameters;

        [JsonIgnore]
        public TransactionData[] Parameters => _parameters;

        public EthSignTransaction(params TransactionData[] transactionDatas) : base()
        {
            this.Method = "eth_signTransaction";
            this._parameters = transactionDatas;
        }
    }
}