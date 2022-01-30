namespace WalletConnectSharp.Core.Models.Ethereum
{
    /// <summary>
    /// A container for representing the native chain currency, such as the name
    /// symbol and how many decimals should be used in formatting
    /// </summary>
    public class NativeCurrency
    {
        public string name;
        public string symbol;
        public int decimals;
    }
}