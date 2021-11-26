﻿using System.Threading.Tasks;
using UnityEngine;
using WalletConnectSharp.Core.Models;
using WalletConnectSharp.Core.Models.Ethereum;
using WalletConnectSharp.Unity;

public class WalletConnectActions : MonoBehaviour
{
    public async Task<string> PersonalSign(string message, int addressIndex = 0)
    {
        var address = WalletConnect.ActiveSession.Accounts[addressIndex];

        var results = await WalletConnect.ActiveSession.EthPersonalSign(address, message);

        return results;
    }
    
    public async Task<string> SendTransaction(TransactionData transaction)
    {
        var results = await WalletConnect.ActiveSession.EthSendTransaction(transaction);

        return results;
    }
    
    public async Task<string> SignTransaction(TransactionData transaction)
    {
        var results = await WalletConnect.ActiveSession.EthSignTransaction(transaction);

        return results;
    }
    
    public async Task<string> SignTypedData<T>(T data, EIP712Domain eip712Domain, int addressIndex = 0)
    {
        var address = WalletConnect.ActiveSession.Accounts[addressIndex];

        var results = await WalletConnect.ActiveSession.EthSignTypedData(address, data, eip712Domain);

        return results;
    }

    public async void CloseSession(bool waitForNewSession = true)
    {
        await WalletConnect.ActiveSession.Disconnect();
        
        if (waitForNewSession)
            await WalletConnect.ActiveSession.Connect();
    }
}
