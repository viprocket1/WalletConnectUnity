namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A container to represent a specific EthChain with chain specific data such as
    /// the name, icons, rpcUrls ect..
    /// </summary>
    public class EthChainData : EthChain
    {
        public string[] blockExplorerUrls;
        public string chainName;
        public string[] iconUrls;
        public NativeCurrency nativeCurrency;
        public string[] rpcUrls;
    }
}