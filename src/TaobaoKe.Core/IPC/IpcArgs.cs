using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.IPC
{
    [Serializable]
    public class IpcArgs
    {
        private IpcArgs()
        {
        }

        public IpcArgs(string content)
        {
            this.Content = content;
        }

        public string Content { get; set; }
    }
}
