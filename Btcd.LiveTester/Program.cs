using System;
using System.Linq;
using System.Net;

namespace Earlz.Btcd.LiveTester
{
    /// <summary>
    /// This is just a simple console program for me to test against the (unautomatable) bitcoind
    /// </summary>
    class MainClass
    {
        public static void Main (string[] args)
        {
            var config = new ConfigParser("/home/earlz/.bitcoin/bitcoin.conf").Read();
            string user = config.Single(x => x.Key == "rpcuser").Value;
            string pass = config.Single(x => x.Key == "rpcpassword").Value;
            string url = "http://127.0.0.1:18332";
            var cred = new NetworkCredential(user, pass);
            Console.WriteLine(user);
            Console.WriteLine(pass);
            var btcd = new Btcd(url, cred);
            Console.WriteLine(btcd.Invoke("getinfo"));
        }
    }
}
