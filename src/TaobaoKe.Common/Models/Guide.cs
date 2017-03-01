using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Common.Models
{
    public class Guide
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
