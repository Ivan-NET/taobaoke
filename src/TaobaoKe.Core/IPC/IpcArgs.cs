using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaobaoKe.Core.IPC
{
    public class IpcArgs
    {
        public IpcArgs(string content)
        {
            this.Content = content;
        }

        public string Content { get; private set; }
    }
}
