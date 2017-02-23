using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using TaobaoKe.Core.IPC;
using TaobaoKe.Core.Log;

namespace Test.IpcClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly a = Assembly.LoadFile(@"C:\Users\ivan\编程\taobaoke\taobaoke\src\Library\System.Data.SQLite.dll");
            
            //记录入口
            LogHelper.Log(LogLevel.DEBUG, LogItemType.System, "DEBUG");
            LogHelper.Log(LogLevel.INFO, LogItemType.System, "INFO");
            LogHelper.Log(LogLevel.WARN, LogItemType.System, "WARN");
            LogHelper.Log(LogLevel.ERROR, LogItemType.System, "ERROR");
            LogHelper.Log(LogLevel.Fatal, LogItemType.System, "Fatal");

            //WaitData();
            //Console.Read();
            NamedPipedIpcClient.Default_A.Start();
            NamedPipedIpcClient.Default_A.Recieve += ipcClient_Recieve;
            Console.WriteLine("client1 start.");
            while (true)
            {
                string value = Console.ReadLine();
                IpcResult result = NamedPipedIpcClient.Default_A.Send(new IpcArgs(value));
                Console.WriteLine(result.Result);
            }
        }

        static string ipcClient_Recieve(IpcArgs args)
        {
            Console.WriteLine(args.Content);
            return "client1 recieved.";
        }

        private static void WaitData()
        {
            using (NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.InOut, 1))
            {
                try
                {
                    pipeServer.WaitForConnection();
                    pipeServer.ReadMode = PipeTransmissionMode.Byte;
                    using (StreamReader sr = new StreamReader(pipeServer))
                    {
                        string con = sr.ReadToEnd();
                        Console.WriteLine(con);
                    }
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
        }
    }
}
