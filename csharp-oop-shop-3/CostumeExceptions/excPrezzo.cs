using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop_3.CostumeExceptions
{
    public class excPrezzo : Exception
    {
        public string message;
        public excPrezzo(string message) : base(message)
        {
            this.message = message;
        }
    }
}
