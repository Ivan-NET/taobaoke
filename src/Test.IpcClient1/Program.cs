using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaobaoKe.Core.IPC;

namespace Test.IpcClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShareMemoryIpcClient ipcClient = new ShareMemoryIpcClient("TaobaoKe_Unique_Name");
            ipcClient.Recieve += ipcClient_Recieve;
            Console.WriteLine("client1 start.");
            while(true)
            {
                string value = Console.ReadLine();
                IpcResult result = ipcClient.Send(new IpcArgs(value));
                Console.WriteLine(result.Result);
            }
        }

        static string ipcClient_Recieve(IpcArgs args)
        {
            Console.WriteLine(args.Content);
            return "client1 recieved.";
        }
    }
}
