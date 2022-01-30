namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A container for representing a transaction request that can be used
    /// in EthSendTransaction
    /// </summary>
    public class TransactionData
    {
        public string from;
        public string to;
        public string data;
        public string gas;
        public string gasPrice;
        public string value;
        public string nonce;
        public int chainId;
    }
}