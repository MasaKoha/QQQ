using System;
using System.Text;

namespace QQQ.Core
{
    public class Base64Decoder : IDecoder
    {
        public string Decode(string param)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(param));
        }
    }
}