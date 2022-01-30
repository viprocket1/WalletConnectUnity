namespace WalletConnectSharp.Core.Models.Ethereum.Types
{
    /// <summary>
    /// A container to represent a type in the EVM
    /// </summary>
    public class EvmTypeInfo
    {
        public string name;
        public string type;

        public EvmTypeInfo(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
    }
}