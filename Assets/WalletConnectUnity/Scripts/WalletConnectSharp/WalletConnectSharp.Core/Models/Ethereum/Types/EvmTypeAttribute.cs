using System;

namespace WalletConnectSharp.Core.Models.Ethereum.Types
{
    /// <summary>
    /// An attribute to specifically target fields when the class
    /// is being encoded in an EvmTypedData object
    /// </summary>
    public class EvmTypeAttribute : Attribute
    {
        /// <summary>
        /// The EVM type to use for this field
        /// </summary>
        public string TypeName { get; }
        
        public EvmTypeAttribute(string typename)
        {
            TypeName = typename;
        }
    }
}