using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day1Hash
{
    class Encryptor
    {
        public static string MakeSha256(string input)
        {
            string output;
            byte[] byteData = Encoding.UTF8.GetBytes(input);
            Stream inputStream = new MemoryStream(byteData);

            using (SHA256 shaM = new SHA256Managed())
            {
                var result = shaM.ComputeHash(inputStream);
                output = BitConverter.ToString(result);
            }
            output = output.Replace("-", "").Substring(0, 5);
            return output;
        }
    }
}
