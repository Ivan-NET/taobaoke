using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using TaobaoKe.Core.IPC;

namespace Test.IpcClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            //SendData();
            //Console.Read();
            NamedPipedIpcClient.Default_B.Start();
            NamedPipedIpcClient.Default_B.Recieve += ipcClient_Recieve;
            Console.WriteLine("client2 start.");
            while (true)
            {
                string value = Console.ReadLine();
                IpcResult result = NamedPipedIpcClient.Default_B.Send(new IpcArgs(value));
                Console.WriteLine(result.Result);
            }
        }

        static string ipcClient_Recieve(IpcArgs args)
        {
            Console.WriteLine(args.Content);
            return "client2 recieved.";
        }

        private static void SendData()
        {
            try
            {
                using (NamedPipeClientStream pipeClient =
              new NamedPipeClientStream("localhost", "testpipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.None))
                {
                    pipeClient.Connect();
                    using (StreamWriter sw = new StreamWriter(pipeClient))
                    {
                        sw.WriteLine("hahha");
                        sw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
