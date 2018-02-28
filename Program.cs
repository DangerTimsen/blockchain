using System;
using NBitcoin;

namespace blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var privateKey = new Key(); //generate random private key (Base58Check)
            var publicKey = privateKey.PubKey;
            BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main);  // generate our Bitcoin secret(also known as Wallet Import Format or simply WIF) from our private key for the mainnet
            BitcoinSecret testNetPrivateKey = privateKey.GetBitcoinSecret(Network.TestNet);  // generate our Bitcoin secret(also known as Wallet Import Format or simply WIF) from our private key for the testnet
            bool WifIsBitcoinSecret = mainNetPrivateKey == privateKey.GetWif(Network.Main);
            var publicKeyHash = publicKey.Hash;

            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);
            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            
            Console.WriteLine();

            Console.WriteLine($"Private Key (Bitcoin Secret) Main: {mainNetPrivateKey}"); 
            Console.WriteLine($"Private Key (Bitcoin Secret) Test: {testNetPrivateKey}");

            Console.WriteLine($"Is WifBitcoinSecret: {WifIsBitcoinSecret}"); // True

            Console.WriteLine();

            Console.WriteLine($"Public Key: {publicKey}");

            Console.WriteLine();

            Console.WriteLine($"Wallet Address Main: {publicKey.GetAddress(Network.Main)}");
            Console.WriteLine($"Wallet Address Test: {publicKey.GetAddress(Network.TestNet)}");

            Console.WriteLine($"Main Net Address: {mainNetAddress}"); 
            Console.WriteLine($"Main Net Address: {testNetAddress}");

            Console.WriteLine();

            Console.WriteLine($"ScriptPubKey Main: {mainNetAddress.ScriptPubKey}");
            Console.WriteLine($"ScriptPubKey Main: {testNetAddress.ScriptPubKey}");
        }
    }
}
