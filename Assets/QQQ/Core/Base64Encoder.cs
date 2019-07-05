using System;
using System.Text;

namespace QQQ.Core
{
    public class Base64Encoder : IEncoder
    {
        public string Encode(string param)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(param));
        }
    }
}